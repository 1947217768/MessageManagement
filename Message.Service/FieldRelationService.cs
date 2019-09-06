using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.IRepository;
using Message.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.Service
{
    public class FieldRelationService : IFieldRelationService
    {
        private readonly IFieldRelationRepository _FieldRelationRepository;
        private readonly IMapper _mapper;

        public FieldRelationService(IFieldRelationRepository FieldRelationRepository, IMapper mapper)
        {
            _FieldRelationRepository = FieldRelationRepository;
            _mapper = mapper;
        }
        public PageInfo<FieldRelation> GetPageList(PageInfo<FieldRelation> pageInfo, FieldRelation oSearchEntity = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _FieldRelationRepository.GetPageList(pageInfo, oSearchEntity, sOperator, iOrderGroup, sSortName, sSortOrder);
        }
        public bool DeleteRange(int[] arrId, string sOperator)
        {
            if (_FieldRelationRepository.DeleteRange(arrId, sOperator) > 0)
            {
                return true;
            }
            return false;
        }

        public List<FieldRelation> SelectALL(FieldRelation entityFieldRelation = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return _FieldRelationRepository.SelectALL(entityFieldRelation, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public FieldRelation Select(int id, string sOperator = null)
        {
            return _FieldRelationRepository.Select(id, sOperator);
        }

        public FieldRelation Select(FieldRelation entityFieldRelation = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return _FieldRelationRepository.Select(entityFieldRelation, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<List<FieldRelation>> SelectALLAsync(FieldRelation entityFieldRelation = null, string sOperator = null, int iOrderGroup = 0, int iMaxCount = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _FieldRelationRepository.SelectALLAsync(entityFieldRelation, sOperator, iOrderGroup, iMaxCount, sSortName, sSortOrder);
        }

        public async Task<FieldRelation> SelectAsync(int id, string sOperator = null)
        {
            return await _FieldRelationRepository.SelectAsync(id, sOperator);
        }

        public async Task<FieldRelation> SelectAsync(FieldRelation entityFieldRelation = null, string sOperator = null, int iOrderGroup = 0, string sSortName = null, string sSortOrder = null)
        {
            return await _FieldRelationRepository.SelectAsync(entityFieldRelation, sOperator, iOrderGroup, sSortName, sSortOrder);
        }

        public async Task<int> AppendAsync(FieldRelation entityFieldRelation, string sOperator)
        {
            return await _FieldRelationRepository.AppendAsync(entityFieldRelation, sOperator);
        }
        public int Append(FieldRelation entityFieldRelation, string sOperator)
        {
            return _FieldRelationRepository.Append(entityFieldRelation, sOperator);
        }

        public async Task<FieldRelation> AddOrModifyFieldRelationAsync(FieldRelation model, string sOperator)
        {
            FieldRelation entityFieldRelation;
            if (model.Id == 0)
            {
                entityFieldRelation = _mapper.Map<FieldRelation>(model);
                await _FieldRelationRepository.AppendAsync(entityFieldRelation, sOperator);
            }
            else
            {
                entityFieldRelation = await _FieldRelationRepository.SelectAsync(model.Id);
                if (entityFieldRelation != null)
                {
                    //_mapper.Map(model, entityFieldRelation);
                    entityFieldRelation.IforeignkeyId = model.IforeignkeyId;
                    entityFieldRelation.IprimarykeyId = model.IprimarykeyId;
                    _FieldRelationRepository.Update(entityFieldRelation, sOperator);
                }
            }
            return entityFieldRelation;
        }
    }
}
