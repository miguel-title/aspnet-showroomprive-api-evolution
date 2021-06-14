using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;


namespace AtomicAPI.Helpers
{
    public class Mapper
    {
     
        //public List<DynamicBeneficiariyDTO> GetDynamicBeneficiaryDTOList(List<TPS.PRISM.Application.Contract.DataTransferObjects.BeneficiaryDTO> list)
        //{
        //    try
        //    {
        //        PRISMConstantsHelper constantsHelper = new PRISMConstantsHelper();

        //        AutoMapper.Mapper.CreateMap<TPS.PRISM.Application.Contract.DataTransferObjects.BeneficiaryDTO, TPS.PRISM.Application.Contract.APITransferObjects.DynamicBeneficiariyDTO>()
        //      .ForMember(x => x.BeneficiaryID, opt => opt.MapFrom(y => y.PadeBeneficiaryID))
        //                    .ForMember(x => x.BeneficiaryRelation, opt => opt.MapFrom(y => y.BeneficiaryRelationshipID))
        //      .ForMember(x => x.City, opt => opt.MapFrom(y => y.CityID))
        //      .ForMember(x => x.CNIC, opt => opt.MapFrom(y => y.CNIC))

        //       .ForMember(x => x.CreditableBankName,
        //           opt => opt.MapFrom
        //           (y => y.BeneficiaryCreditablesListDTO.Count() > 0 ? y.BeneficiaryCreditablesListDTO[0].CreditableBankName : null)).
        //      ForMember(x => x.BeneficiaryName, opt => opt.MapFrom(y => y.Name))
        //       .ForMember(x => x.CurrencyCode,
        //           opt => opt.MapFrom
        //           (y => y.BeneficiaryCreditablesListDTO.Count() > 0 ? y.BeneficiaryCreditablesListDTO[0].CurrencyAlphaCode : null)).
        //      ForMember(x => x.Email, opt => opt.MapFrom(y => y.EmailAddress)).
        //      ForMember(x => x.MobileNumber, opt => opt.MapFrom(y => y.MobileNumber))
        //       .ForMember(x => x.CreditableTitle,
        //           opt => opt.MapFrom
        //           (y => y.BeneficiaryCreditablesListDTO.Count() > 0 ? y.BeneficiaryCreditablesListDTO[0].Title : null));
        //        List<TPS.PRISM.Application.Contract.APITransferObjects.DynamicBeneficiariyDTO> LIst = AutoMapper.Mapper.Map<List<TPS.PRISM.Application.Contract.APITransferObjects.DynamicBeneficiariyDTO>>(list);

        //        foreach (var beneficiary in LIst)
        //        {
        //            try
        //            {
        //                beneficiary.CSV = Convert.ToString(ConfigurationHelper.GetFoIntitutionData(constantsHelper.BankCode, beneficiary.ModuleID, SessionWrapper.CustomerDTO.LanguageID, SessionWrapper.CustomerDTO.Source));
                        
        //                if (!string.IsNullOrEmpty(beneficiary.BeneficiaryRelation))
        //                {
        //                    try { beneficiary.BeneficiaryRelation = SessionWrapper.BeneficiaryRelationList.Where(x => x.Value == beneficiary.BeneficiaryRelation).ToList()[0].Text; }
        //                    catch (Exception) { }
                          
        //                }
        //                if (!string.IsNullOrEmpty(beneficiary.City))
        //                {
        //                    if (SessionWrapper.CityList == null || SessionWrapper.CityList.Count == 0)
        //                    {
        //                        List<SelectListItem> CityList = new List<SelectListItem>();
        //                        new ConstantsHelper().GetCitiesList(out CityList);
        //                        SessionWrapper.CityList = CityList;
        //                    }
        //                    try { beneficiary.City = SessionWrapper.CityList.Where(x => x.Value == beneficiary.City).ToList()[0].Text; }
        //                    catch (Exception) { }
        //                }
        //            }
        //            catch (Exception)
        //            {
                        
        //            }
        //        }

        //        return LIst;
        //    }
        //    catch (Exception Ex)
        //    {
        //        #region File Logging
        //        LogManager.GetUILogger().Info(
        //        new LogMessage()
        //            .AddUserIdentifier("Mapper-GetDynamicBeneficiaryDTOList")
        //            .AddSource("Mapper-GetDynamicBeneficiaryDTOList")
        //            .AddText(Ex.ToString())
        //        );
        //        #endregion File Logging
        //        return null;
        //    }
        //}
    }
}