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
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        public UserInfoService(IUserInfoRepository userInfoRepository, IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _userRoleRepository = userRoleRepository;
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
                List<UserRole> lstUserRole = await _userRoleRepository.SelectALLAsync(entityUserRole);
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
                await _userInfoRepository.InsertAsync(entityUserInfo, sOperator);
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
            await _userRoleRepository.AddOrDeleteUserRoleAsync(entityUserInfo.Id, model.lstRoleId, sOperator);
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
        //public void Redis(int iUserId)
        //{
        //    UserInfo entityUserInfo = _userInfoRepository.Select(iUserId);
        //    if (entityUserInfo != null)
        //    {
        //        if (RedisHelper.Exists(entityUserInfo.SloginName + "_UserMenu"))
        //        {
        //            RedisHelper.Del(entityUserInfo.SloginName + "_UserMenu");
        //        }
        //        //用户菜树Redis Key
        //        string sUserTreeItemMenuKey = entityUserInfo.SloginName + "_UserTreeItemMenu";
        //        if (RedisHelper.Exists(sUserTreeItemMenuKey))
        //        {
        //            RedisHelper.Del(sUserTreeItemMenuKey);
        //        }
        //    }
        //}
    }
}
