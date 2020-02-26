//Enums
public enum HelperCategory
{
    [Description("Category not assigned")]
    Nonee,
    [Description("CCTV Installation and Fixing")]
    Cctv,
    [Description("Network Planning and Troubleshooting")]
    NetworkPlanning,
    [Description("PABX - Private Automatic Issues")]
    Pabx,
    [Description("Cisco Routing - Service Maintenance")]
    Cisco,
    [Description("IT and other projects")]
    IT,
    [Description("Office Relocation IT Setup")]
    OfficeRelocation,
    [Description("Office New IT Setup")]
    OfficeNewSetup,
    [Description("Basic Hardware Repairing")]
    HardwareRepair,

}

//Extension method to get description
public static string GetDescription(this Enum value)
{

    var x = value
            .GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description
            ?? value.ToString();
    return x;
}

//Example of service method to use "GetDescription"
public async Task<List<HelperCategoryListBO>> GetAllHelperCategoryAsync()
{
    try
    {
        List<HelperCategoryListBO> helperCategoryList = new List<HelperCategoryListBO>();
        Array values = Enum.GetValues(typeof(Enums.HelperCategory));

        foreach (Enums.HelperCategory val in values)
        {
            helperCategoryList.Add(new HelperCategoryListBO
            {
                Key = (int)val,
                Value = val.GetDescription()
            });
        }
        return helperCategoryList;
    }
    catch (Exception ex)
    {

        throw ex;
    }

}


