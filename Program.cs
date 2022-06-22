using EmployeeData;
using EmployeeData.Entities;


public class Program
{
    public static CRUDManager crud = new CRUDManager();
    public static void Main()
    {
        //Insert crud-operation
        //#region
        //List<Organisation> orgList2 = new List<Organisation>();
        //orgList2.Add(new Organisation { OrgName = "Appinventive" });
        //orgList2.Add(new Organisation { OrgName = "Amazon" });
        //crud.InsertInOrgs(new Employee { Name = "Dipakshi", Address = "UttarPradesh" }, orgList2);
        //#endregion



        //Read Employee and Organization table crud-operation
        ShowAllEmpOrgsDetails();
        


        //update employee with organizationslist
        List<Organisation> OrgList = new List<Organisation>();
        OrgList.Add(new Organisation { OrgName="Accenture"});
        OrgList.Add(new Organisation { OrgName = "Kellton" });
        OrgList.Add(new Organisation { OrgName = "Wipro" });

        crud.UpdateEmpOrgs(5, new Employee { Name = "Shatakshi", Address = "Lucknow" }, OrgList);
        Console.ReadKey();


        //delete crud
        //crud.DeleteImpOrg(4);




    }

    public static void ShowAllEmpOrgsDetails()
    {
        foreach (Employee item in crud.ReadEmployeeWithOrgs())
        {
            Console.Write($"EId: {item.ID}\tEName: {item.Name}\tEAddress: {item.Address}\t");
            foreach (Organisation Oitem in item.OrganisationList)
            {
                Console.WriteLine($"OId: {Oitem.ID}\tOName: {Oitem.OrgName}");
            }
        }
    }
}
