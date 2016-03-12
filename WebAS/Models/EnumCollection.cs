using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAS.Resources;

namespace WebAS.Models
{

    #region Country Enum Collection
    public enum Country
    {
        [Display(Name="CountryGB", Description = "Country", ResourceType = typeof(EnumResource))]
        GB = 0,

        [Display(Name="CountryFI", Description = "Country", ResourceType = typeof(EnumResource))]
        FI = 1,

        [Display(Name="CountrySE", Description = "Country", ResourceType = typeof(EnumResource))]
        SE = 2,

        [Display(Name="CountryNO", Description = "Country", ResourceType = typeof(EnumResource))]
        NO = 3,

        [Display(Name="CountryFR", Description = "Country", ResourceType = typeof(EnumResource))]
        FR = 4,

        [Display(Name = "CountryES", Description = "Country", ResourceType = typeof(EnumResource))]
        ES = 5,

        [Display(Name = "CountryDE", Description = "Country", ResourceType = typeof(EnumResource))]
        DE = 6
    }
    #endregion Country Enum Collection

    #region Language Enum Collection
    public enum Language
    {
        [Display(Name = "LanguageEN", ResourceType = typeof(EnumResource))]
        EN = 0,

        [Display(Name = "LanguageFI", ResourceType = typeof(EnumResource))]
        FI = 1,

        [Display(Name = "LanguageSV", ResourceType = typeof(EnumResource))]
        SV = 2,

        [Display(Name = "LanguageNO", ResourceType = typeof(EnumResource))]
        NO = 3,

        [Display(Name = "LanguageFR", ResourceType = typeof(EnumResource))]
        FR = 4,

        [Display(Name = "LanguageES", ResourceType = typeof(EnumResource))]
        ES = 5,

        [Display(Name = "LanguageDE", ResourceType = typeof(EnumResource))]
        DE = 6
    }
    #endregion Language Enum Collection

    #region Gender Enum Collection
    public enum Gender
    {
        [Display(Name = "GenderMale", ResourceType = typeof(EnumResource))]
        Male,
        [Display(Name = "GenderFemale", ResourceType = typeof(EnumResource))]
        Female
    }
    #endregion Gender Enum Collection
}