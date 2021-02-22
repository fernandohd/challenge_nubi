using AutoMapper;
using Challenge.Application.Models;
using Challenge.Domain.DataModels;
using Challenge.Domain.Entities;

namespace Challenge.Api.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Pais
            CreateMap<PaisDataModel, PaisModel>();
            CreateMap<GeoInformationDataModel, GeoInformationModel>();
            CreateMap<LocationDataModel, LocationModel>();
            CreateMap<StateDataModel, StateModel>();
            #endregion

            #region Item
            CreateMap<ItemDataModel, ItemModel>();
            CreateMap<AvailableFilterDataModel, AvailableFilterModel>();
            CreateMap<AvailableFilterValueDataModel, AvailableFilterValueModel>();
            CreateMap<SortDataModel, SortModel>();
            CreateMap<FilterDataModel, FilterModel>();
            CreateMap<FilterValueDataModel, FilterValueModel>();
            CreateMap<PagingDataModel, PagingModel>();
            CreateMap<ResultDataModel, ResultModel>().ForMember(d => d.SellerId, o => o.MapFrom(s => s.Seller.Id));
            #endregion

            #region User
            CreateMap<UserEntity, UserModel>().ReverseMap();
            #endregion

            #region Moneda
            CreateMap<CurrencyDataModel, CurrencyModel>().ForMember(d => d.CurrencyId, o => o.MapFrom(s => s.Id));
            CreateMap<ConversionDataModel, ConversionModel>();

            CreateMap<ConversionModel, ConversionEntity>();
            CreateMap<CurrencyModel, CurrencyHistoryEntity>();
            #endregion
        }
    }
}
