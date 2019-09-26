using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Entity.ViewEntity.Memo;
using Message.IRepository;
using Message.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.Service
{
    public class MemoService : IMemoService
    {
        private readonly IMemoRepository _memorandumRepository;
        private readonly IMapper _mapper;

        public MemoService(IMemoRepository memorandumRepository, IMapper mapper)
        {
            _memorandumRepository = memorandumRepository;
            _mapper = mapper;
        }
        public PageInfo<Memo> GetPageList(PageInfo<Memo> pageInfo, Memo oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _memorandumRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_memorandumRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }

        public List<Memo> SelectALL(Memo entityMemorandum = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _memorandumRepository.SelectALL(entityMemorandum, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public Memo Select(int id, string sOperator = null)
        {
            return _memorandumRepository.Select(id, sOperator);
        }

        public Memo Select(Memo entityMemorandum = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _memorandumRepository.Select(entityMemorandum, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<Memo>> SelectALLAsync(Memo entityMemorandum = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _memorandumRepository.SelectALLAsync(entityMemorandum, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<Memo> SelectAsync(int id, string sOperator = null)
        {
            return await _memorandumRepository.SelectAsync(id, sOperator);
        }

        public async Task<Memo> SelectAsync(Memo entityMemorandum = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _memorandumRepository.SelectAsync(entityMemorandum, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(Memo entityMemorandum, string sOperator)
        {
            return await _memorandumRepository.AppendAsync(entityMemorandum, sOperator);
        }
        public int Append(Memo entityMemorandum, string sOperator)
        {
            return _memorandumRepository.Append(entityMemorandum, sOperator);
        }

        public async Task<Memo> AddOrModifyMemorandumAsync(AddOrModifyMemo model, string sOperator)
        {
            Memo entityMemorandum;
            if (model.Id == 0)
            {
                entityMemorandum = _mapper.Map<Memo>(model);
                await _memorandumRepository.AppendAsync(entityMemorandum, sOperator);
            }
            else
            {
                entityMemorandum = await _memorandumRepository.SelectAsync(model.Id);
                if (entityMemorandum != null)
                {
                    _mapper.Map(model, entityMemorandum);
                    _memorandumRepository.Update(entityMemorandum, sOperator);
                }
            }
            return entityMemorandum;
        }

        public int Update(Memo entityMemorandum, string sOperator)
        {
            return _memorandumRepository.Update(entityMemorandum, sOperator);
        }
    }
}
