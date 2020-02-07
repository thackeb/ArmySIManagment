using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ArmySIManagment.BuisnessLogic;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using ArmySIManagment.Connectors;
namespace ArmySIManagment.GUI.ViewModels
{
   public class MainViewModel : Conductor<Screen>.Collection.AllActive, IScreen
    {
        public Dictionary<int, string> RankDict = new Dictionary<int, string>
        {
           {1, "E1" },
           {2, "E2"},
           {3, "E3"},
           {4, "E4"},
           {5, "E5"},
           {6, "E6"},
           {7, "E7"},
           {8,  "E8"},
           {9,  "E9"},
           {10, "W1"},
           {11, "W2"},
           {12, "W3"},
           {13, "W4"},
           {14, "W5"},
           {15, "O1"},
           {16, "O2"},
           {17, "O3"},
           {18, "O4"},
           {19, "O5"},
           {20, "O6"},
           {21, "O7"},
           {22, "O8"},
           {23, "O9"}
        };
        public Dictionary<string, int> RankDictRev = new Dictionary<string, int>
        {
           { "E1",1},
           { "E2",2},
           { "E3",3},
           { "E4",4},
           { "E5",5},
           { "E6",6},
           { "E7",7},
           { "E8",8},
           { "E9",9},
           { "W1",10},
           { "W2",11},
           { "W3",12},
           { "W4",13},
           { "W5",14},
           { "O1",15},
           { "O2",16},
           { "O3",17},
           { "O4",18},
           { "O5",19},
           { "O6",20},
           { "O7",21},
           { "O8",22},
           { "O9",23}
        };
        public Dictionary<int, string> DrillStatus = new Dictionary<int, string>
        {
            {0,"Main Body" },
            {1,"Advon" },
            {2,"Rear" },
            {3,"AWOL" },
            {4,"Absent" }
        };
        public Dictionary<string, int> DrillStatusRev = new Dictionary<string, int>
        {
            {"Main Body",0 },
            {"Advon",1 },
            {"Rear",2 },
            {"AWOL",3 },
            {"Absent",4 }
        };
        Dictionary<string, int> ExcelTables = new Dictionary<string, int>
        {
            { "Soldiers",1 },
            { "M4Rifle",2 },
            { "ACOG",3 },
            { "M240B",4 },
            { "M145MGO",5 },
            { "PEQ2s" ,6},
            { "PEQ15s",7 },
            { "PVS14s",8 },
            { "MBITR",9 },
            { "ASIP",10 },
            { "M249SAW",11 }
        };
        public Dictionary<int, string> WeaponRosterSheets = new Dictionary<int, string>
        {
            { 0,"M4" },
            { 1,"M-9" },
            { 2,"M249" },
            { 3,"M500" },
            { 4,"M240" },
            {5,"ACOG" },
            {6,"M240B" },
            {7,"PEQ2" },
            {8,"PEQ15" },
            {9,"PVS14" },
            {10,"MBITR" },
            {11,"ASIP" },
            {12,"PAS-13" },

        };

        Dictionary<string, int> ExportedExcelSheetDict = new Dictionary<string, int>
        {
            {    "M4"      ,  0 },
            {    "M-9"     ,  1 },
            {    "M249"    ,  2 },
            {    "M500"    ,  3 },
            {    "M240"    ,  4 },
            {     "ACOG"   , 5   },
            {     "M240B"  , 6   },
            {     "PEQ2"   , 7   },
            {     "PEQ15"  , 8   },
            {     "PVS14"  , 9   },
            {"MBITR"    ,10 },
            {"ASIP"     ,11 },
            {"FirstName",12 },
            {"LastName" ,13 },
            {"Position" ,14 },
            {"DOD#"     ,15 },
            {"Rank"     ,16 },
            {"Platoon"  ,17 }

        };

        public Dictionary<string, int> AssignedPlatoon = new Dictionary<string, int>
        {
            { "None",1 },
            { "1ST PLT",1 },
            { "2ND PLT",2 },
            { "3RD PLT",3 },
            { "HQ PLT",4 },
        };
        public Dictionary<int, string> AssignedPlatoonRev = new Dictionary<int, string>
        {
            { 0,"None" },
            { 1,"1ST PLT" },
            { 2,"2ND PLT" },
            { 3,"3RD PLT" },
            { 4,"HQ PLT" },
        };
        public Dictionary<string, int> SoldierAttr = new Dictionary<string, int>
        {
            {"FirstName",1 },
            {"LastName",2 },
            {"Position",3 },
            {"DOD#",4 },
            {"Rank",5 },
            {"Platoon",6 }
        };
        public Dictionary<string, int> SensitiveItemAttr = new Dictionary<string, int>
        {
            {"Serial#",1 }
        };
        private ArmySIExcelSheet _armySIExcelSheet ;
        private List<SensitiveItemBaseClass> _sensitiveItemsList;
        private List<WeaponAssignments> _weaponAssignmentsList;
        private List<Soldier> _soldiersList;
        private List<Roles> _rolesList;
        private List<RoleAssignments> _roleAssignmentsList;

        public List<RoleAssignments> RolesAssignmentsList
        {
            get
            {
                return _roleAssignmentsList;
            }
            set
            {
                _roleAssignmentsList = value;
                NotifyOfPropertyChange(() => RolesAssignmentsList);
            }
        }

        public List<Roles> RolesList
        {
            get
            {
                return _rolesList;
            }
            set
            {
                _rolesList = value;
                NotifyOfPropertyChange(() => RolesList);
            }
        }


        public List<Soldier> SoldiersList
        {
            get
            {
                return _soldiersList;
            }
            set
            {
                _soldiersList = value;
                NotifyOfPropertyChange(() => SoldiersList);
            }
        }


        public List<WeaponAssignments> WeaponAssignmentsList
        {
            get
            {
                return _weaponAssignmentsList;
            }
            set
            {
                _weaponAssignmentsList = value;
                NotifyOfPropertyChange(() => WeaponAssignmentsList);
            }
        }

        public ArmySIExcelSheet ArmySIExcelSheet
        {
            get
            {
                return _armySIExcelSheet;
            }
            set
            {
                _armySIExcelSheet = value;
                NotifyOfPropertyChange(() => ArmySIExcelSheet);
            }
        }

    

        public List<SensitiveItemBaseClass> SensitiveItemsList
        {
            get
            {
                return _sensitiveItemsList;
            }
            set
            {
                _sensitiveItemsList = value;
                NotifyOfPropertyChange(() => SensitiveItemsList);
            }
        }




        public MainViewModel()
        {
            ArmySIExcelSheet = new ArmySIExcelSheet();
            SensitiveItemsList = ArmyDataBaseConnector.LoadSensitiveItemList();
 
            RolesList = ArmyDataBaseConnector.LoadRoles();
            SoldiersList = ArmyDataBaseConnector.LoadSoldierInfo();
            RolesAssignmentsList = ArmyDataBaseConnector.LoadRoleAssignments(SoldiersList, RolesList);
            WeaponAssignmentsList = ArmyDataBaseConnector.LoadWeaponAssignments(RolesList, SensitiveItemsList);
            Items.Add(new SoldierRosterPlatoonTabControlViewModel(this));
            Items.Add(new SensitiveItemTabControlViewModel(SensitiveItemsList, RolesAssignmentsList, WeaponAssignmentsList));
            Items.Add(new RolesInformationViewModel(this));
            Items.Add(new FinalReportViewModel(SoldiersList, SensitiveItemsList, WeaponAssignmentsList, RolesList, RolesAssignmentsList));
            //ArmySIExcelSheet.ExportSISheet("test.xlsx", SoldiersList, WeaponAssignmentsList, RolesList, RolesAssignmentsList, SensitiveItemsList);
        }
        public MainViewModel(string filePath)
        {


            ArmySIExcelSheet = new ArmySIExcelSheet(filePath);
   
            
            foreach (SensitiveItemBaseClass si in ArmySIExcelSheet.SIList.AllItems)
            {
                ArmyDataBaseConnector.SaveSensitiveItem(si);
            }
            foreach(Soldier soldier in ArmySIExcelSheet.SoldierList)
            {
                ArmyDataBaseConnector.SaveSoldierInfo(soldier);
            }

            SensitiveItemsList = ArmyDataBaseConnector.LoadSensitiveItemList();
            ArmySIExcelSheet.RolesList = ArmyDataBaseConnector.LoadRoles();
            RolesList = ArmyDataBaseConnector.LoadRoles();
            SoldiersList = ArmyDataBaseConnector.LoadSoldierInfo();
            RolesAssignmentsList = ArmyDataBaseConnector.LoadRoleAssignments(SoldiersList, RolesList);
            WeaponAssignmentsList = ArmyDataBaseConnector.LoadWeaponAssignments(RolesList, SensitiveItemsList);
            /*//Test Stuff out
            ArmySIExcelSheet.SoldierList = ArmyDataBaseConnector.LoadSoldierInfo();
            ArmySIExcelSheet.SIList.AllItems = ArmyDataBaseConnector.LoadSensitiveItemList();
            Roles testRole = new Roles();
            //testing role stuff
            testRole.FireTeam = 1;
            testRole.Platoon = 1;
            testRole.RoleName = "Alpha Team Leader";
            testRole.Squad = 1;
            testRole.RoleID = ArmyDataBaseConnector.SaveRole(testRole);

            //Testing Assigned Roles
            RoleAssignments roleAssignments = new RoleAssignments();
            roleAssignments.Role = testRole;
            roleAssignments.AssignedSoldier = _armySIExcelSheet.SoldierList[10];
            ArmyDataBaseConnector.SaveRoleAssignments(roleAssignments);

            //Testing loading Assigned Roles
            List<Roles> roles = new List<Roles>();
            roles.Add(testRole);
            List<RoleAssignments> roleAssignments1 = ArmyDataBaseConnector.LoadRoleAssignments(ArmySIExcelSheet.SoldierList, roles);

            //Testing Weapon Assignments
            WeaponAssignments weaponAssignments = new WeaponAssignments();
            weaponAssignments.AssignedSI.Add(ArmySIExcelSheet.SIList.AllItems[110]);
            weaponAssignments.Role = testRole;
            ArmyDataBaseConnector.SaveWeaponAssignments(weaponAssignments);
            ArmyDataBaseConnector.RemoveWeaponAssignmnet(weaponAssignments, ArmySIExcelSheet.SIList.AllItems[110]);

            //End of testing stuff*/
            Items.Add(new SoldierRosterPlatoonTabControlViewModel(this));
            Items.Add(new SensitiveItemTabControlViewModel(SensitiveItemsList, RolesAssignmentsList, WeaponAssignmentsList));
            Items.Add(new RolesInformationViewModel(this));
            Items.Add(new FinalReportViewModel(SoldiersList,SensitiveItemsList, WeaponAssignmentsList,RolesList,RolesAssignmentsList));
            ArmySIExcelSheet.ExportSISheet("test.xlsx", SoldiersList, WeaponAssignmentsList, RolesList, RolesAssignmentsList, SensitiveItemsList);
        }
    }
}
