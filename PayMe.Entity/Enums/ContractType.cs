using System.ComponentModel.DataAnnotations;

namespace PayMe.Entity
{
    public enum ContractType
    {
        [Display(Name = "Full Time")]
        FullTime,
        [Display(Name = "Fix Term")]
        FixedTerm,
        [Display(Name = "Part Time")]
        PartTime,
        Casual
    }
}