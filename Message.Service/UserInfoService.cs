using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.UserInfo;
using Message.IRepository;
using Message.IService;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.Service
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;
        public UserInfoService(IUserInfoRepository userInfoRepository, IUserRoleService userRoleService, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _userRoleService = userRoleService;
            _mapper = mapper;
        }
        public PageInfo<UserInfo> GetPageList(PageInfo<UserInfo> pageInfo, UserInfo oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _userInfoRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public async Task<UserInfo> CheckUserAsync(string sLoginName, string sLoginPwd, string sLoginIp = null)
        {
            if (string.IsNullOrWhiteSpace(sLoginName) || string.IsNullOrWhiteSpace(sLoginPwd))
            {
                return null;
            }
            UserInfo entityUserInfo = await _userInfoRepository.SelectAsync(new UserInfo() { SloginName = sLoginName });
            if (entityUserInfo != null)
            {
                string sEncryptPwd = EncryptHelper.EncryptPasswordMd5(EncryptHelper.Encode(sLoginPwd, EncryptHelper.AesEncryptKeys));
                if (entityUserInfo.SloginPwd == sEncryptPwd)
                {
                    if (!string.IsNullOrWhiteSpace(sLoginIp))
                    {
                        if (entityUserInfo.SloginLastIp != sLoginIp)
                        {
                            entityUserInfo.SloginLastIp = sLoginIp;
                        }
                    }
                    entityUserInfo.TloginLastTime = DateTime.Now;
                    _userInfoRepository.Update(entityUserInfo, entityUserInfo.SloginName);
                    return entityUserInfo;
                }
            }
            return null;
        }

        public async Task<List<UserRole>> GetUserRoleListAsync(UserRole entityUserRole, string sSortOrder = null)
        {
            if (entityUserRole != null)
            {
                List<UserRole> lstUserRole = await _userRoleService.SelectALLAsync(entityUserRole);
                return lstUserRole;
            }
            return null;
        }

        public async Task<UserInfo> AddOrModifyUserInfoAsync(AddOrModifyUserInfo model, string sOperator)
        {
            UserInfo entityUserInfo;
            if (model.Id == 0)
            {
                entityUserInfo = _mapper.Map<UserInfo>(model);
                //加密  使用默认密码
                entityUserInfo.SloginPwd = EncryptHelper.EncryptPasswordMd5(EncryptHelper.Encode(entityUserInfo.SloginPwd, EncryptHelper.AesEncryptKeys));
                await _userInfoRepository.AppendAsync(entityUserInfo, sOperator);
            }
            else
            {
                entityUserInfo = await _userInfoRepository.SelectAsync(model.Id);
                if (entityUserInfo != null)
                {
                    model.SloginPwd = entityUserInfo.SloginPwd;
                    _mapper.Map(model, entityUserInfo);
                    _userInfoRepository.Update(entityUserInfo, sOperator);
                }
            }
            await _userRoleService.AddOrDeleteUserRoleAsync(entityUserInfo.Id, model.lstRoleId, sOperator);
            return entityUserInfo;
        }
        public async Task<bool> ChangeUserLockStatusAsync(ChangeUserStatus entity, string sOperator)
        {
            UserInfo entityUserInfo = await _userInfoRepository.SelectAsync(entity.Id);
            if (entityUserInfo != null)
            {
                entityUserInfo.BisLock = entity.BisLock;
                _userInfoRepository.Update(entityUserInfo, sOperator);
                return true;
            }
            return false;
        }
        public async Task<UserInfo> GetUserInfoAsync(UserInfo entityUserInfo, string sOperator = null)
        {
            return await _userInfoRepository.SelectAsync(entityUserInfo, sOperator);
        }
        public UserInfo ChangeUserPassWord(UserInfo entity, string sOperator)
        {
            if (entity != null)
            {
                entity.SloginPwd = EncryptHelper.EncryptPasswordMd5(EncryptHelper.Encode(entity.SloginPwd, EncryptHelper.AesEncryptKeys));
                _userInfoRepository.Update(entity, sOperator);
            }
            return entity;
        }

        public bool DeleteRange(int[] arrUserId, string sOperator)
        {
            if (_userInfoRepository.DeleteRange(arrUserId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<List<UserInfo>> GetUserInfoListAsync(UserInfo entityUserInfo = null, string sOperator = null)
        {
            return await _userInfoRepository.SelectALLAsync(entityUserInfo);
        }


        public async Task<List<UserInfo>> SelectALLAsync(UserInfo entityUserInfo = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _userInfoRepository.SelectALLAsync(entityUserInfo, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }
        public async Task<UserInfo> SelectAsync(int id, string sOperator = null)
        {
            return await _userInfoRepository.SelectAsync(id, sOperator);
        }
        public async Task<UserInfo> SelectAsync(UserInfo entityUserInfo = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _userInfoRepository.SelectAsync(entityUserInfo, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public List<UserInfo> SelectALL(UserInfo entityUserInfo = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _userInfoRepository.SelectALL(entityUserInfo, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public UserInfo Select(int id, string sOperator = null)
        {
            return _userInfoRepository.Select(id, sOperator);
        }

        public UserInfo Select(UserInfo entityUserInfo = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _userInfoRepository.Select(entityUserInfo, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

    }
}
