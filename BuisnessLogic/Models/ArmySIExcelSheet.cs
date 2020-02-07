using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Microsoft.Office.Interop.Excel;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using System.Reflection;
using System.Windows;

namespace ArmySIManagment.BuisnessLogic.Models
{
    
    public class ArmySIExcelSheet : BaseModel
    {
        private Microsoft.Office.Interop.Excel.Application _excelApp;
        private Workbook _excelWorkbook;
        private string _filePath;
        private List<Soldier> _soldierList;
        private SensitiveItemList _siList;
        private List<Roles> _rolesList;
        private List<WeaponAssignments> _weaponAssignmentsList;
        private List<RoleAssignments> _roleAssignmentsList;

        public List<RoleAssignments> RoleAssignmentsList
        {
            get
            {
                return _roleAssignmentsList;
            }
            set
            {
                SetProperty(ref _roleAssignmentsList, value);
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
                SetProperty(ref _weaponAssignmentsList, value);
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
                SetProperty(ref _rolesList, value);
            }
        }


        public Microsoft.Office.Interop.Excel.Application ExcelApp
        {
            get
            {
                return _excelApp;
            }
            set
            {
                SetProperty(ref _excelApp, value);
            }
        }
        public Workbook ExcelWorkbook
        {
            get
            {
                return _excelWorkbook;
            }
            set
            {
                SetProperty(ref _excelWorkbook, value);
            }
        }
        public string FilePath
        { 
            get
            {
                return _filePath;
            }
            set
            {
                SetProperty(ref _filePath, value);
            }
        }
        public List<Soldier> SoldierList
        {
            get
            {
                return _soldierList;
            }
            set
            {
                SetProperty(ref _soldierList, value);
            }
        }
        public SensitiveItemList SIList
        {
            get
            {
                return _siList;
            }
            set
            {
                SetProperty(ref _siList, value);
            }
        }
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
        public Dictionary<string ,int> RankDictRev = new Dictionary<string, int>
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
        Dictionary <string, int> ExcelTables =new Dictionary<string, int>
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
       public  Dictionary<int, string> WeaponRosterSheets = new Dictionary<int, string>
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

        Dictionary< string,int> ExportedExcelSheetDict = new Dictionary< string,int>
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

        public Dictionary<int, string> SensitiveItemSheets = new Dictionary<int, string>
        {
            { 0,"HQ" },
            { 1,"1st PLT" },
            { 2,"2nd PLT" },
            { 3,"3rd PLT" },
   

        };
        public Dictionary<string, int> SensitiveItemCategories = new Dictionary<string, int>
        {
            {"Name",0 },
            {"POS",1 },
            {"Weapon Serial #",2 },
            {"CCO/SIGHT #",3 },
            {"Night Vision #",4 },
            {"Radio",5 },
            {"Bino/Spotting Scope #",6 },
            {"DAGR",7 },
            {"PEQ-2",8 },
            {"PAS-13 Light",9 },
            {"PAS-13 MED/HVY",10 },
            {"MISC/Secondary Weapon",11 },

        };
        public List<string> SensitiveItemFillerStrings = new List<string>
        {
            {"HQ" },
            {"Mortars" },
            {"NAME" },
            { "WEAPON SERIAL #"},
            { "CCO/SIGHT #"},
            { "NIGHT VISION #"},
            { "RADIO"},
            { "BINO / SPOTTING SCOPE"},
            { "DAGR"},
            { "PEQ-2"},
            { "PAS-13 LIGHT"},
            { "PAS-13 MED/HVY"},
            { "MISC / Secondary Weapon"},
            { "1st SQD"},
            { "2nd SQD"},
            { "3rd SQD"},
            { "Weapons"},
        };
        public ArmySIExcelSheet ()
        {
            _excelApp = new Microsoft.Office.Interop.Excel.Application();

            _excelApp.Visible = false;
             _filePath = "NULL";
            _soldierList = new List<Soldier>();
            _siList = new SensitiveItemList();
            RolesList = new List<Roles>();
            WeaponAssignmentsList = new List<WeaponAssignments>();
            RoleAssignmentsList = new List<RoleAssignments>();
        }
        public ArmySIExcelSheet(string FilePath)
        {
            _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _excelApp.Visible = true;
            _excelWorkbook = _excelApp.Workbooks.Open(FilePath);
            _filePath = FilePath;
            _soldierList = new List<Soldier>();
            _siList = new SensitiveItemList();
            RolesList = new List<Roles>();
            WeaponAssignmentsList = new List<WeaponAssignments>();
            RoleAssignmentsList = new List<RoleAssignments>();
        }
     
       
        public int ParseArmySIList ()
        {
            
            Worksheet DataWorkSheet = _excelWorkbook.Worksheets["Data"];
            try
            {


                foreach (ListObject table in DataWorkSheet.ListObjects)
                {
                    try
                    {


                        int tableType = 0;
                        ExcelTables.TryGetValue(table.DisplayName, out tableType);
                        switch (tableType)
                        {
                            case 1: //Soldiers
                                {

                                    foreach (ListRow soldierRow in table.ListRows)
                                    {
                                        Soldier newSoldier = new Soldier();
                                        foreach (ListColumn soldierCol in table.ListColumns)
                                        {

                                            int soldierAttrType = 0;

                                            SoldierAttr.TryGetValue(soldierCol.Name, out soldierAttrType);
                                            switch (soldierAttrType)
                                            {
                                                case 1://FirstName
                                                    {
                                                        if (soldierRow.Range[soldierCol.Index].Value != null)
                                                            newSoldier.FirstName = soldierRow.Range[soldierCol.Index].Value;
                                                        break;
                                                    }
                                                case 2://Lastname
                                                    {
                                                        if (soldierRow.Range[soldierCol.Index].Value != null)
                                                            newSoldier.LastName = soldierRow.Range[soldierCol.Index].Value;
                                                        break;
                                                    }
                                                case 3://Position
                                                    {
                                                        if (soldierRow.Range[soldierCol.Index].Value != null)
                                                            newSoldier.Role = soldierRow.Range[soldierCol.Index].Value;
                                                        break;
                                                    }
                                                case 4://DOD#
                                                    {

                                                        if (soldierRow.Range[soldierCol.Index].Value != null)
                                                            newSoldier.DODNum = soldierRow.Range[soldierCol.Index].Value;


                                                        break;
                                                    }
                                                case 5://Rank
                                                    {

                                                        if (soldierRow.Range[soldierCol.Index].Value != null)
                                                            newSoldier.Rank = soldierRow.Range[soldierCol.Index].Value;
                                                        break;
                                                    }
                                                case 6://Platoon
                                                    {

                                                        if (soldierRow.Range[soldierCol.Index].Value != null)
                                                            newSoldier.Platoon = soldierRow.Range[soldierCol.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }

                                        }
                                        _soldierList.Add(newSoldier);
                                    }
                                    break;
                                }
                            case 2: //M4
                                {
                                    foreach (ListRow m4Row in table.ListRows)
                                    {
                                        M4 newM4 = new M4();
                                        foreach (ListColumn m4Col in table.ListColumns)
                                        {
                                            int m4AttrType = 0;
                                            SensitiveItemAttr.TryGetValue(m4Col.Name, out m4AttrType);

                                            switch (m4AttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (m4Row.Range[m4Col.Index].Value != null)
                                                            newM4.SerialNumber = m4Row.Range[m4Col.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.M4.Add(newM4);
                                    }
                                    break;
                                }
                            case 3: //Acog
                                {
                                    foreach (ListRow ACOGRow in table.ListRows)
                                    {
                                        ACOG newACOG = new ACOG();
                                        foreach (ListColumn ACOGCol in table.ListColumns)
                                        {
                                            int ACOGAttrType = 0;
                                            SensitiveItemAttr.TryGetValue(ACOGCol.Name, out ACOGAttrType);

                                            switch (ACOGAttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (ACOGRow.Range[ACOGCol.Index].Value != null)
                                                            newACOG.SerialNumber = ACOGRow.Range[ACOGCol.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.ACOGs.Add(newACOG);
                                    }
                                    break;
                                }
                            case 4: //M240B
                                {
                                    foreach (ListRow M240BRow in table.ListRows)
                                    {
                                        M240B newM240B = new M240B();
                                        foreach (ListColumn M240BCol in table.ListColumns)
                                        {
                                            int M240BType = 0;
                                            SensitiveItemAttr.TryGetValue(M240BCol.Name, out M240BType);

                                            switch (M240BType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (M240BRow.Range[M240BCol.Index].Value!= null)
                                                            newM240B.SerialNumber = M240BRow.Range[M240BCol.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.M240b.Add(newM240B);
                                    }
                                    break;
                                }
                            case 5: //M145
                                {
                                    foreach (ListRow M145Row in table.ListRows)
                                    {
                                        M145 newM145 = new M145();
                                        foreach (ListColumn M145Col in table.ListColumns)
                                        {
                                            int M145AttrType = 0;
                                            SensitiveItemAttr.TryGetValue(M145Col.Name, out M145AttrType);

                                            switch (M145AttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (M145Row.Range[M145Col.Index].Value!= null)
                                                            newM145.SerialNumber = M145Row.Range[M145Col.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.M145.Add(newM145);
                                    }
                                    break;
                                }
                            case 6: //PEQ2
                                {
                                    foreach (ListRow PEQ2Row in table.ListRows)
                                    {
                                        PEQ2 newPEQ2 = new PEQ2();
                                        foreach (ListColumn PEQ2Col in table.ListColumns)
                                        {
                                            int PEQ2AttrType = 0;
                                            SensitiveItemAttr.TryGetValue(PEQ2Col.Name, out PEQ2AttrType);

                                            switch (PEQ2AttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (PEQ2Row.Range[PEQ2Col.Index].Value != null)
                                                            newPEQ2.SerialNumber = PEQ2Row.Range[PEQ2Col.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.PEQ2.Add(newPEQ2);
                                    }
                                    break;
                                }
                            case 7: //PEQ15
                                {
                                    foreach (ListRow PEQ15Row in table.ListRows)
                                    {
                                        PEQ15 newPEQ15 = new PEQ15();
                                        foreach (ListColumn PEQ15Col in table.ListColumns)
                                        {
                                            int PEQ15AttrType = 0;
                                            SensitiveItemAttr.TryGetValue(PEQ15Col.Name, out PEQ15AttrType);

                                            switch (PEQ15AttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (PEQ15Row.Range[PEQ15Col.Index].Value != null)
                                                            newPEQ15.SerialNumber = PEQ15Row.Range[PEQ15Col.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.PEQ15.Add(newPEQ15);
                                    }
                                    break;
                                }
                            case 8: //PVS14
                                {
                                    foreach (ListRow PVS14Row in table.ListRows)
                                    {
                                        PVS14 newPVS14 = new PVS14();
                                        foreach (ListColumn PVS14Col in table.ListColumns)
                                        {
                                            int PVS14AttrType = 0;
                                            SensitiveItemAttr.TryGetValue(PVS14Col.Name, out PVS14AttrType);

                                            switch (PVS14AttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (PVS14Row.Range[PVS14Col.Index].Value != null)
                                                            newPVS14.SerialNumber = PVS14Row.Range[PVS14Col.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.PVS14.Add(newPVS14);
                                    }
                                    break;
                                }
                            case 9: //MBITR
                                {
                                    foreach (ListRow MBITRRow in table.ListRows)
                                    {
                                        MBITR newMBITR = new MBITR();
                                        foreach (ListColumn MBITRCol in table.ListColumns)
                                        {
                                            int MBITRAttrType = 0;
                                            SensitiveItemAttr.TryGetValue(MBITRCol.Name, out MBITRAttrType);

                                            switch (MBITRAttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (MBITRRow.Range[MBITRCol.Index].Value != null)
                                                            newMBITR.SerialNumber = MBITRRow.Range[MBITRCol.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.MBITR.Add(newMBITR);
                                    }
                                    break;
                                }
                            case 10: //ASIP
                                {
                                    foreach (ListRow ASIPRow in table.ListRows)
                                    {
                                        Asip newASIP = new Asip();
                                        foreach (ListColumn ASIPCol in table.ListColumns)
                                        {
                                            int ASIPAttrType = 0;
                                            SensitiveItemAttr.TryGetValue(ASIPCol.Name, out ASIPAttrType);

                                            switch (ASIPAttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (ASIPRow.Range[ASIPCol.Index].Value != null)
                                                            newASIP.SerialNumber = ASIPRow.Range[ASIPCol.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.Asip.Add(newASIP);
                                    }
                                    break;
                                }
                            case 11: //M249SAW
                                {
                                    foreach (ListRow M249Row in table.ListRows)
                                    {
                                        M249 newM249 = new M249();
                                        foreach (ListColumn M249Col in table.ListColumns)
                                        {
                                            int M249AttrType = 0;
                                            SensitiveItemAttr.TryGetValue(M249Col.Name, out M249AttrType);

                                            switch (M249AttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (M249Row.Range[M249Col.Index].Value != null)
                                                            newM249.SerialNumber = M249Row.Range[M249Col.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.M249.Add(newM249);
                                    }
                                    break;
                                }
                            default:
                                {
                                    foreach (ListRow OtherItemsRow in table.ListRows)
                                    {
                                        OtherItems newOtherItems = new OtherItems();
                                        foreach (ListColumn OtherItemsCol in table.ListColumns)
                                        {
                                            int OtherItemsAttrType = 0;
                                            SensitiveItemAttr.TryGetValue(OtherItemsCol.Name, out OtherItemsAttrType);

                                            switch (OtherItemsAttrType)
                                            {
                                                case 1://Serial#
                                                    {
                                                        if (OtherItemsRow.Range[OtherItemsCol.Index].Value != null)
                                                            newOtherItems.SerialNumber = OtherItemsRow.Range[OtherItemsCol.Index].Value;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                        }
                                        _siList.OtherItems.Add(newOtherItems);
                                    }
                                    break;
                                }
                        }
                        
                    }
                    catch (InvalidDataException e)
                    {
                         MessageBox.Show($"Security error.\n\nError message: {e.Message}\n\n" +
                    $"Details:\n\n{e.StackTrace}");
                    }



                }
            }
            catch (InvalidDataException e)
            {

            }
            return 1;
        }

        public int ParseArmyWeaponRoster ()
        {
            //First Get all sheets in the Excel Workbook
            List<Worksheet> weaponRosterSheets = new List<Worksheet>();
            weaponRosterSheets.Add(_excelWorkbook.Worksheets[WeaponRosterSheets[0]]); //M4
            weaponRosterSheets.Add(_excelWorkbook.Worksheets[WeaponRosterSheets[1]]); //M-9
            weaponRosterSheets.Add(_excelWorkbook.Worksheets[WeaponRosterSheets[2]]); //M249
            weaponRosterSheets.Add(_excelWorkbook.Worksheets[WeaponRosterSheets[3]]); //M500
            weaponRosterSheets.Add(_excelWorkbook.Worksheets[WeaponRosterSheets[4]]); //M240

            
            List<string> soldierNames = new List<string>();
            List<string> headers = new List<string> { "RECEIVING SOLDIERS NAME", "(PRINTED & SIGNED)","WEAPON ","TYPE","ADMIN #" ,"SERIAL #" , "ASSIGNED" , "PLT", "OPTIC" , "Armorer's Initials" };
            int worksheetItr = 0;
            foreach (Worksheet worksheet in weaponRosterSheets)
            {

                


                //Get all columns without null values
                IEnumerable<object> weaponTypeResults = GetNonNullValuesInColumn(_excelApp, worksheet, "A");
                IEnumerable<object> adminNumResults = GetNonNullValuesInColumn(_excelApp, worksheet, "B");
                
                //Need to filter out adminNumResults
                //Need to do is to check if soldier name is null or not, 
                //This will determine if it is to be added to soldier list or not
                //This will be acheived by iterating through all ADMIN #
                //And checking the corresponding E col for a null value
                //This will be tricky since the M4 starts at E5 and the rest start at E3
                int i = 3;
                
                if (worksheetItr == 0 )
                {
                     i = 5;
                    
                }

                foreach (object adminNum in adminNumResults)
                {
                    if (adminNum.ToString().Contains("ADMIN #") != true)
                    {
                        //First Parse the SI and it to the list
                        switch (worksheetItr)
                        {
                            case 0://M4
                                {
                                    M4 newM4 = new M4();
                                    string m4SerialCellValue = (string)(worksheet.Cells[i, "C"]).Value;
                                    if (headers.Contains(m4SerialCellValue) != true & m4SerialCellValue != null)
                                    {
                                        m4SerialCellValue = m4SerialCellValue.Replace("W", "");
                                        newM4.SerialNumber = Convert.ToDouble(m4SerialCellValue);
                                        newM4.RosterNumber = adminNum.ToString();
                                        _siList.M4.Add(newM4);
                                        _siList.AllItems.Add(newM4);
                                        _siList.SIDictionary.Add(_siList.M4.Last().SerialNumber, adminNum.ToString());
                                        ACOG acog = new ACOG();
                                        //Now Check Acog
                                        string acogSerialCellValue = Convert.ToString((worksheet.Cells[i, "H"]).Value);
                                        //It can contain two values, one for acog, one for m320 or peq15
                                        if (acogSerialCellValue != null)
                                        {
                                            if (acogSerialCellValue.Contains("(15)"))
                                            {
                                                PEQ15 peq15 = new PEQ15();
                                                //It has a peq15 value
                                                double splitAcogDouble = Convert.ToDouble(acogSerialCellValue.Split('/')[0]);
                                                double splitPeq15Double = Convert.ToDouble((acogSerialCellValue.Split('/')[1]).Replace("(15)", ""));

                                                acog.SerialNumber = splitAcogDouble;
                                                peq15.SerialNumber = splitPeq15Double;
                                                peq15.RosterNumber = Convert.ToString(adminNum);
                                                acog.RosterNumber = Convert.ToString(adminNum);
                                                //Time to add it to the SI list
                                                _siList.ACOGs.Add(acog);
                                                _siList.PEQ15.Add(peq15);
                                                _siList.AllItems.Add(peq15);
                                                _siList.AllItems.Add(acog);
                                                _siList.SIDictionary.Add(_siList.PEQ15.Last().SerialNumber, adminNum.ToString());



                                            }
                                            else if (acogSerialCellValue.Contains("-"))
                                            {
                                                //it contains m320
                                                M320A1 m320 = new M320A1();
                                                //It has a M320 value
                                                if (acogSerialCellValue.Contains("/"))
                                                {
                                                    double splitAcogDouble = Convert.ToDouble(acogSerialCellValue.Split('/')[0]);
                                                    double splitM320Double = Convert.ToDouble((acogSerialCellValue.Split('/')[1]).Replace("-", ""));
                                                    acog.RosterNumber = Convert.ToString(adminNum);
                                                    acog.SerialNumber = splitAcogDouble;
                                                    m320.RosterNumber = Convert.ToString(adminNum);
                                                    m320.SerialNumber = splitM320Double;
                                                    //Time to add it to the SI list
                                                    _siList.ACOGs.Add(acog);
                                                    _siList.M320A1.Add(m320);
                                                    _siList.AllItems.Add(m320);
                                                    _siList.AllItems.Add(acog);
                                                    _siList.SIDictionary.Add(_siList.ACOGs.Last().SerialNumber, adminNum.ToString());
                                                    _siList.SIDictionary.Add(_siList.M320A1.Last().SerialNumber, adminNum.ToString());
                                                }
                                                else
                                                {
                                                    double splitM320Double = Convert.ToDouble((acogSerialCellValue.Replace("-", "")));
                                                    m320.RosterNumber = Convert.ToString(adminNum);
                                                    m320.SerialNumber = splitM320Double;
                                                    _siList.M320A1.Add(m320);
                                                    _siList.SIDictionary.Add(_siList.M320A1.Last().SerialNumber, adminNum.ToString());
                                                    _siList.AllItems.Add(m320);
                                                }
                                                
                                            }
                                            else
                                            {
                                                double splitAcogDouble = Convert.ToDouble(acogSerialCellValue);
                                                acog.SerialNumber = splitAcogDouble;
                                                acog.RosterNumber = Convert.ToString(adminNum);
                                                _siList.ACOGs.Add(acog);
                                                _siList.SIDictionary.Add(_siList.ACOGs.Last().SerialNumber, adminNum.ToString());
                                                _siList.AllItems.Add(acog);
                                            }
                                        }
                                    }
                                    break;
                                }
                            case 1://M-9
                                {
                                    M9 newM4 = new M9();
                                    try
                                    {
                                        double m4SerialCellValue = (worksheet.Cells[i, "C"]).Value;
                                        newM4.SerialNumber = Convert.ToDouble(m4SerialCellValue);
                                        newM4.RosterNumber = Convert.ToString(adminNum);
                                        _siList.M9.Add(newM4);
                                        _siList.SIDictionary.Add(_siList.M9.Last().SerialNumber, adminNum.ToString());
                                        _siList.AllItems.Add(newM4);
                                    }
                                    catch (Exception e)
                                    {

                                    }

                                    break;
                                }
                            case 2://M249
                                {


                                    M249 newM4 = new M249();
                                    var m4SerialCellValue = (worksheet.Cells[i, "C"]).Value;

                                    newM4.SerialNumber = Convert.ToDouble(m4SerialCellValue);
                                    newM4.RosterNumber = Convert.ToString(adminNum);
                                    _siList.M249.Add(newM4);
                                    _siList.SIDictionary.Add(_siList.M249.Last().SerialNumber, adminNum.ToString());
                                    _siList.AllItems.Add(newM4);


                                    var ccoSerialCellValue = (worksheet.Cells[i, "G"]).Value;
                                    if (ccoSerialCellValue != null)
                                    {
                                        CCO newCCO = new CCO();
                                        newCCO.SerialNumber = Convert.ToDouble(ccoSerialCellValue);
                                        newCCO.RosterNumber = Convert.ToString(adminNum);
                                        _siList.CCO.Add(newCCO);
                                        _siList.SIDictionary.Add(_siList.CCO.Last().SerialNumber, adminNum.ToString());
                                        _siList.AllItems.Add(newCCO);
                                    }

                                    break;
                                }
                            case 3://M500
                                {
                                    M500 newM4 = new M500();
                                    string m4SerialCellValue = (string)(worksheet.Cells[i, "C"]).Value;
                                    if (headers.Contains(m4SerialCellValue) != true & m4SerialCellValue != null)
                                    {
                                        m4SerialCellValue = m4SerialCellValue.Replace("US", "");
                                        newM4.SerialNumber = Convert.ToDouble(m4SerialCellValue);
                                        newM4.RosterNumber = Convert.ToString(adminNum);
                                        _siList.M500.Add(newM4);
                                        _siList.SIDictionary.Add(_siList.M500.Last().SerialNumber, adminNum.ToString());
                                        _siList.AllItems.Add(newM4);
                                    }

                                    break;
                                }
                            case 4://M240
                                {
                                    M240B newM4 = new M240B();
                                    string m4SerialCellValue = (string)(worksheet.Cells[i, "C"]).Value;
                                    if (headers.Contains(m4SerialCellValue) != true & m4SerialCellValue != null)
                                    {
                                        m4SerialCellValue = m4SerialCellValue.Replace("U", "");
                                        newM4.SerialNumber = Convert.ToDouble(m4SerialCellValue);
                                        newM4.RosterNumber = Convert.ToString(adminNum);
                                        _siList.M240b.Add(newM4);
                                        _siList.SIDictionary.Add(_siList.M240b.Last().SerialNumber, adminNum.ToString());
                                        _siList.AllItems.Add(newM4);
                                    }
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        };
                        string soldierNameCellValue = (string)(worksheet.Cells[i, "E"]).Value;
                        //if the CellValue is not Null
                        //Then create a soldier
                        //Add him to the list with the roster number
                        //With the SI
                        //Check to make sure he doesn't already exist
                        if (headers.Contains(soldierNameCellValue) != true && soldierNameCellValue != null)
                        {
                            //Get index of the ','
                            int index = soldierNameCellValue.IndexOf(',');
                            //Now get the last name
                            string lastName = soldierNameCellValue.Substring(0, index);
                            //Now First name
                            //Have to setup the length var
                            int length = soldierNameCellValue.Length - index - 1;
                            string firstName = soldierNameCellValue.Substring(index + 1, length);

                            if (soldierNames.Contains(soldierNameCellValue) != true)
                            {
                                string soldierPlatoonCellValue;
                                try
                                {
                                  
                                    Soldier soldier = new Soldier();
                                    soldier.FirstName = firstName;
                                    soldier.LastName = lastName;
                                    soldier.AdminNumber = Convert.ToString(adminNum);
                                    if (worksheetItr != 2)
                                    {
                                        soldierPlatoonCellValue = Convert.ToString((worksheet.Cells[i, "G"]).Value);
                                        if (soldierPlatoonCellValue != null)
                                            soldier.Platoon = AssignedPlatoon[soldierPlatoonCellValue.ToUpper()];
                                    }
                                    //Add name to list to keep track of soldiers, avoids duplicates
                                    soldierNames.Add(soldierNameCellValue);
                                    _soldierList.Add(soldier);
                                }
                                
                                catch (Exception e)
                                {
                                    MessageBox.Show("Soldier Name is " + firstName + lastName, "\n\nTrying to Parse Sheet " + worksheetItr);
                                }
                            }



                            foreach (Soldier soldier in _soldierList)
                            {
                                if (soldier.LastName == lastName && soldier.FirstName == firstName)
                                {
                                    int indexOfSoldier = _soldierList.IndexOf(soldier);
                                    switch (worksheetItr)
                                    {
                                        case 0://M4
                                            {
                                                _soldierList[indexOfSoldier].AssignedSI.M4.Add(_siList.M4.Last());
                                                _soldierList[indexOfSoldier].AssignedSI.ACOGs.Add(_siList.ACOGs.Last());

                                                _soldierList[indexOfSoldier].AssignedSIDictionary.Add( _siList.M4.Last().SerialNumber,"M4");
                                                
                                                string acogAdmin = adminNum.ToString();
                                                acogAdmin = acogAdmin + "ACOG";
                                                _soldierList[indexOfSoldier].AssignedSIDictionary.Add( _siList.ACOGs.Last().SerialNumber,"ACOG");
                                                
                                                break;
                                            }
                                        case 1://M-9
                                            {

                                                _soldierList[indexOfSoldier].AssignedSI.M9.Add(_siList.M9.Last());
                                                _soldierList[indexOfSoldier].AssignedSIDictionary.Add(_siList.M9.Last().SerialNumber, "M9");
                                               

                                                break;
                                            }
                                        case 2://M249
                                            {

                                                _soldierList[indexOfSoldier].AssignedSI.M249.Add(_siList.M249.Last());
                                                _soldierList[indexOfSoldier].AssignedSIDictionary.Add(_siList.M249.Last().SerialNumber, "M249");
                                               
                                                break;
                                            }
                                        case 3://M500
                                            {
                                                _soldierList[indexOfSoldier].AssignedSI.M500.Add(_siList.M500.Last());
                                                _soldierList[indexOfSoldier].AssignedSIDictionary.Add(_siList.M500.Last().SerialNumber, "M500");
                                               


                                                break;
                                            }
                                        case 4://M240
                                            {
                                                _soldierList[indexOfSoldier].AssignedSI.M240b.Add(_siList.M240b.Last());
                                                _soldierList[indexOfSoldier].AssignedSIDictionary.Add(_siList.M240b.Last().SerialNumber, "M240B");

                                               
                                                break;
                                            }
                                        default:
                                            {
                                                break;
                                            }
                                    };

                                }
                            }
                        }
                        i = i + 2;
                    }
                }

             

                worksheetItr = worksheetItr + 1;
            }
            //Will all names, time to split them by first and last 
            //Will use the ',' as the split
          


            return 1;
        }
        public int ExportExcelSISheet ( string fileName)
        {
            try
            {
                Worksheet exportWorksheet = _excelWorkbook.Worksheets.Add();
                exportWorksheet.Name = fileName;
            
                 var range = (Range)exportWorksheet.get_Range("A1").Cells[1, 1];

                 ListObject list = exportWorksheet.ListObjects.AddEx(SourceType: XlListObjectSourceType.xlSrcRange, Source: range, XlListObjectHasHeaders: XlYesNoGuess.xlYes);
                list.Name = "SI Roster";
                ListColumn PlatoonCol = list.ListColumns.Item[1];
                PlatoonCol.Name = "Platoon";
            ListColumn LastNameCol = list.ListColumns.Add();
            LastNameCol.Name = "Last Name";
            ListColumn FirstNameCol = list.ListColumns.Add();
            FirstNameCol.Name = "First Name";
                ListColumn RankCol = list.ListColumns.Add();
                RankCol.Name = "Rank";
                ListColumn PositionCol = list.ListColumns.Add();
                PositionCol.Name = "Position";
                ListColumn StatusCol = list.ListColumns.Add();
            StatusCol.Name = "Status";

            ListColumn M4Col = list.ListColumns.Add();
            M4Col.Name = "M4";
            ListColumn M240BCol = list.ListColumns.Add();
            M240BCol.Name = "M240B";
            ListColumn M249Col = list.ListColumns.Add();
            M249Col.Name = "M249";
            ListColumn M9Col = list.ListColumns.Add();
            M9Col.Name = "M9";
            ListColumn ACOGCol = list.ListColumns.Add();
            ACOGCol.Name = "ACOG";
            ListColumn M320A1Col = list.ListColumns.Add();
            M320A1Col.Name = "M320A1";
            ListColumn CCOCol = list.ListColumns.Add();
            CCOCol.Name = "CCO";
            ListColumn PEQ15Col = list.ListColumns.Add();
            PEQ15Col.Name = "PEQ15";
            ListColumn PVS14Col = list.ListColumns.Add();
            PVS14Col.Name = "PVS-14";
            ListColumn PVS7Col = list.ListColumns.Add();
            PVS7Col.Name = "PVS-7";
            ListColumn MBITRCol = list.ListColumns.Add();
            MBITRCol.Name = "MBITR";
            ListColumn ASIPCol = list.ListColumns.Add();
            ASIPCol.Name = "ASIP";
            ListColumn M40Col = list.ListColumns.Add();
            M40Col.Name = "M40";
            ListColumn M500Col = list.ListColumns.Add();
            M500Col.Name = "M500";
            ListColumn M145Col = list.ListColumns.Add();
            M145Col.Name = "M145";
            ListColumn PEQ2Col = list.ListColumns.Add();
            PEQ2Col.Name = "PEQ2";
            //System.Data.DataTable soldierInfoTable = new System.Data.DataTable();

            //soldierInfoTable.Columns.Add("Platoon");
            //soldierInfoTable.Columns.Add("Last Name");
            //soldierInfoTable.Columns.Add("First Name");
            //soldierInfoTable.Columns.Add("Status");
            //soldierInfoTable.Columns.Add("AssignedSI");
            /*   soldierInfoTable.Columns.Add("M249");
                soldierInfoTable.Columns.Add("M240B");
                soldierInfoTable.Columns.Add("ACOG");
                soldierInfoTable.Columns.Add("M320A1");
                soldierInfoTable.Columns.Add("CCO");
                soldierInfoTable.Columns.Add("PEQ15");
                soldierInfoTable.Columns.Add("PVS-14");
                soldierInfoTable.Columns.Add("PVS-7");
                soldierInfoTable.Columns.Add("MBITR");
                soldierInfoTable.Columns.Add("ASIP");
                soldierInfoTable.Columns.Add("M40");  
                soldierInfoTable.Columns.Add("M500");
                soldierInfoTable.Columns.Add("M145");
                soldierInfoTable.Columns.Add("PEQ2");*/

            //soldierInfoTable.Columns.Add("Other");
            int r = 2; 
            foreach (Soldier sol in SoldierList)
            {
                ListRow cur = list.ListRows.AddEx();

                PlatoonCol.Range[r].Value = AssignedPlatoonRev[Convert.ToInt32( sol.Platoon)];
                    RankCol.Range[r].Value =  RankDict[ Convert.ToInt32(sol.Rank)];
                    PositionCol.Range[r].Value = sol.Role;
                LastNameCol.Range[r].Value = sol.LastName;
                FirstNameCol.Range[r].Value = sol.FirstName;
                StatusCol.Range[r].Value = DrillStatus[ sol.Status];
                foreach (KeyValuePair<double,string> kp in sol.AssignedSIDictionary)
                {
                    switch (kp.Value)
                    {
                        case "M4"   :{
                                M4Col.Range[r].Value = kp.Key;
                            break;
                                     }
                        case "M-9"  :{
                                M9Col.Range[r].Value = kp.Key;
                                break;
                                    }
                        case "M249" :{
                                M249Col.Range[r].Value = kp.Key;
                                break;
                                    }
                        case "M500" :{

                                M500Col.Range[r].Value = kp.Key;
                                break;
                                    }
                        case "M240" :{
                                M240BCol.Range[r].Value = kp.Key;
                                break;
                                    }
                        case "ACOG" :{
                                ACOGCol.Range[r].Value = kp.Key;
                                break;
                                    }
                        case "M240B":{
                                M240BCol.Range[r].Value = kp.Key;
                                break;
                                    }
                        case "PEQ2" :{
                                PEQ2Col.Range[r].Value = kp.Key;
                                break;
                                    }
                        case "PEQ15":{
                                PEQ15Col.Range[r].Value = kp.Key;
                                break;
                                    }
                        case "PVS14":
                            { 
                            PVS14Col.Range[r].Value = kp.Key;
                             break;
                                    }
                        case "MBITR":{
                                MBITRCol.Range[r].Value = kp.Key;
                                break;
                                    } 
                        case "ASIP" :{
                                ASIPCol.Range[r].Value = kp.Key;

                                break;
                                     }
                    }
                }
                //AssignedSICol.Range[r].Value = sol.AssignedSIDictionary;
                r++;
                //soldierInfoTable.Rows.Add(sol.Platoon, sol.LastName, sol.FirstName, DrillStatus[sol.Status], sol.AssignedSIDictionary);
            }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Security error.\n\nError message: {e.Message}\n\n" +
                     $"Details:\n\n{e.StackTrace}");
            }

            return 1;
    }
        public int ParseArmySIExcelApp(string sheetToOpen)
        {
            if(sheetToOpen != null)
            {
                try
                {
                    Worksheet DataWorkSheet = _excelWorkbook.Worksheets[sheetToOpen];
                    ListObject list = DataWorkSheet.ListObjects.Item[1];
                    foreach(ListRow row in list.ListRows)
                    {
                        try
                        {
                            Soldier sol = new Soldier();
                            sol.Platoon = AssignedPlatoon[ row.Range[1].Value];
                            sol.LastName = row.Range[2].Value;
                            sol.FirstName = row.Range[3].Value;
                            sol.Rank = RankDictRev[ row.Range[4].Value];
                            sol.Status = DrillStatusRev[ row.Range[6].Value];
                            sol.Role =  row.Range[5].Value;
                            if(row.Range[7].Value != null )
                            {
                                sol.AssignedSIDictionary.Add(row.Range[7].Value, "M4");
                            }
                            if (row.Range[8].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[8].Value, "M240B");
                            }
                            if (row.Range[9].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[9].Value, "M249");
                            }
                            if (row.Range[10].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[10].Value, "M9");
                            }
                            if (row.Range[11].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[11].Value, "ACOG");
                            }
                            if (row.Range[12].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[12].Value, "M320A");
                            }
                            if (row.Range[13].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[13].Value, "CCO");
                            }
                            if (row.Range[14].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[14].Value, "PEQ15");
                            }
                            if (row.Range[15].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[15].Value, "PVS-14");
                            }
                            if (row.Range[16].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[16].Value, "PVS-7");
                            }
                            if (row.Range[17].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[17].Value, "MBITR");
                            }
                            if (row.Range[18].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[18].Value, "ASIP");
                            }
                            if (row.Range[19].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[19].Value, "M40");
                            }
                            if (row.Range[20].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[20].Value, "M500");
                            }
                            if (row.Range[21].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[21].Value, "M145");
                            }
                            if (row.Range[22].Value != null)
                            {
                                sol.AssignedSIDictionary.Add(row.Range[22].Value, "PEQ2");
                            }
                            _soldierList.Add(sol);
                        }
                        catch (Exception ev)
                        {
                            MessageBox.Show($"Security error.\n\nError message: {ev.Message}\n\n" +
                    $"Details:\n\n{ev.StackTrace}");
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                
            }
            return 1;
        }
        private static IEnumerable<object> GetNonNullValuesInColumn(_Application application, _Worksheet worksheet, string columnName )
        {
            // get the intersection of the column and the used range on the sheet (this is a superset of the non-null cells)
            var tempRange = application.Intersect(worksheet.UsedRange, (Range)worksheet.Columns[columnName]);

            // if there is no intersection, there are no values in the column
            if (tempRange == null)
                yield break;

            // get complete set of values from the temp range (potentially memory-intensive)
            var value = tempRange.Value2;

            // if value is NULL, it's a single cell with no value
            if (value == null)
                yield break;
            //if value is equal to filter, break
          
            // if value is not an array, the temp range was a single cell with a value
            if (!(value is Array))
            {
                yield return value;
                yield break;
            }

            // otherwise, the value is a 2-D array
            var value2 = (object[,])value;
            var rowCount = value2.GetLength(0);
            for (var row = 1; row <= rowCount; ++row)
            {
                var v = value2[row, 1];
                if (v != null)
                    yield return v;
            }
        }

        public int ParseSensitiveItemsExcelSheet ()
        {
            //First Get all sheets in the Excel Workbook
            List<Worksheet> weaponRosterSheets = new List<Worksheet>();
            weaponRosterSheets.Add(_excelWorkbook.Worksheets[SensitiveItemSheets[0]]); //HQ
            weaponRosterSheets.Add(_excelWorkbook.Worksheets[SensitiveItemSheets[1]]); //1stPLT
            weaponRosterSheets.Add(_excelWorkbook.Worksheets[SensitiveItemSheets[2]]); //2ndPLT
            weaponRosterSheets.Add(_excelWorkbook.Worksheets[SensitiveItemSheets[3]]); //3rdPLT
                                                                                      //Parse HQ Sheet differently then other ones
            IEnumerable<object> nameResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "A");
            IEnumerable<object> posResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "B");
            IEnumerable<object> weaponSerialNumResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "C");
            IEnumerable<object> CCOSightNumResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "D");
            IEnumerable<object> nightVisionNumResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "E");
            IEnumerable<object> radioResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "F");
            IEnumerable<object> binoResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "G");
            IEnumerable<object> dagrNumResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "H");
            IEnumerable<object> peq2Results = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "I");
            IEnumerable<object> pas13LightResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "J");
            IEnumerable<object> pas13MedResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "K");
            IEnumerable<object> miscResults = GetNonNullValuesInColumn(_excelApp, weaponRosterSheets[0], "L");

            foreach(object result in nameResults)
            {
                
            }


            return 1;
        }
        public int ExportSISheet(string fileName, List<Soldier> soldiers, List<WeaponAssignments> weaponAssignments, List<Roles> roles, List<RoleAssignments> roleAssignments, List<SensitiveItemBaseClass> sensitiveItemBaseClasses)
        {
            //Create SI List

            Microsoft.Office.Interop.Excel.Application oXl = new Microsoft.Office.Interop.Excel.Application();
            oXl.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook workbook = oXl.Workbooks.Add();
            Worksheet siSheet = workbook.Worksheets.Add();
            siSheet.Name = "Sensitive Items";

            var range = (Range)siSheet.get_Range("A1").Cells[1, 1];

            ListObject siList = siSheet.ListObjects.AddEx(SourceType: XlListObjectSourceType.xlSrcRange, Source: range, XlListObjectHasHeaders: XlYesNoGuess.xlYes);
            siList.Name = "Sensitive Item List";
           
            Dictionary<string, List<int>> siDict = new Dictionary<string, List<int>>();
            //Generate the table for each Equipment Type and its SI
            foreach(SensitiveItemBaseClass si in sensitiveItemBaseClasses)
            {
                if(!siDict.ContainsKey(si.EquipmentName))
                {
                    siDict.Add(si.EquipmentName, new List<int>());
                    siDict[si.EquipmentName].Add(Convert.ToInt32(si.SerialNumber));
                }
                else
                {
                    siDict[si.EquipmentName].Add(Convert.ToInt32( si.SerialNumber)); ;
                }
            }
            //Create the Dictionary for the platoon rosters
            Dictionary<string, Dictionary<string, List<string>>> platoonSquadSoldierDict = new Dictionary<string, Dictionary<string, List<string>>>();
            foreach(RoleAssignments roleAssignments1 in roleAssignments)
            {
                if (!platoonSquadSoldierDict.ContainsKey(roleAssignments1.Role.PlatoonString))
                {
                    platoonSquadSoldierDict.Add(roleAssignments1.Role.PlatoonString, new Dictionary<string, List<string>>());
                    if (!platoonSquadSoldierDict[roleAssignments1.Role.PlatoonString].ContainsKey(roleAssignments1.Role.SquadString))
                    {
                        platoonSquadSoldierDict[roleAssignments1.Role.PlatoonString].Add(roleAssignments1.Role.SquadString, new List<string>());
                        platoonSquadSoldierDict[roleAssignments1.Role.PlatoonString][roleAssignments1.Role.SquadString].Add(roleAssignments1.AssignedSoldier.LastName + "," + roleAssignments1.AssignedSoldier.FirstName);
                    }
                    else
                    {
                        platoonSquadSoldierDict[roleAssignments1.Role.PlatoonString][roleAssignments1.Role.SquadString].Add(roleAssignments1.AssignedSoldier.LastName + "," + roleAssignments1.AssignedSoldier.FirstName);
                    }
                   
                }
                else
                {
                    if (!platoonSquadSoldierDict[roleAssignments1.Role.PlatoonString].ContainsKey(roleAssignments1.Role.SquadString))
                    {
                        platoonSquadSoldierDict[roleAssignments1.Role.PlatoonString].Add(roleAssignments1.Role.SquadString, new List<string>());
                        platoonSquadSoldierDict[roleAssignments1.Role.PlatoonString][roleAssignments1.Role.SquadString].Add(roleAssignments1.AssignedSoldier.LastName + "," + roleAssignments1.AssignedSoldier.FirstName);
                    }
                    else
                    {
                        platoonSquadSoldierDict[roleAssignments1.Role.PlatoonString][roleAssignments1.Role.SquadString].Add(roleAssignments1.AssignedSoldier.LastName + "," + roleAssignments1.AssignedSoldier.FirstName);
                    }
               
                }
            }


            //Create the list
            foreach(KeyValuePair<string,List<int>> keyValuePair in siDict)
            {
                ListColumn siCol = siList.ListColumns.Add();
                siCol.Name = keyValuePair.Key;
                int i = 2;
                foreach(int serialNum in keyValuePair.Value)
                {
                    siCol.Range[i].Value = serialNum;
                    i++;
                }
            }
            //Create the dictionary for Soldier to WeaponAssignments
            Dictionary<Soldier,KeyValuePair<string, List<SensitiveItemBaseClass>>> soldierWeaponAssignments = new Dictionary<Soldier, KeyValuePair<string, List<SensitiveItemBaseClass>>>();
            foreach(Soldier soldier in soldiers)
            {
                soldierWeaponAssignments.Add(soldier, new KeyValuePair<string, List<SensitiveItemBaseClass>>());
                foreach (RoleAssignments assignments in roleAssignments)
                {
                    if (soldier == assignments.AssignedSoldier)
                    {
                        soldierWeaponAssignments[soldier] =new KeyValuePair<string, List<SensitiveItemBaseClass>>(assignments.Role.RoleName, new List<SensitiveItemBaseClass>());
                        foreach (WeaponAssignments weaponAssignments1 in weaponAssignments)
                        {
                            if (assignments.Role == weaponAssignments1.Role)
                            {
                                foreach (SensitiveItemBaseClass si in weaponAssignments1.AssignedSI)
                                {
                                    soldierWeaponAssignments[soldier].Value.Add(si);
                                }
                            }
                        }
                    }
                }
            }
            //Add Plt Sheets for each plt
           
            foreach(KeyValuePair<string,Dictionary<string,List<string>>> keyValuePair1 in platoonSquadSoldierDict)
            {
                Worksheet pltSheet = workbook.Worksheets.Add();
                pltSheet.Name = keyValuePair1.Key;

                var range2 = (Range)pltSheet.get_Range("A1").Cells[1, 1];
                //Create A table for each squad, add a seperator in between each sqd 
                int i = 2;
                int count = 2;
                foreach (KeyValuePair<string,List<string>> keyValuePair in keyValuePair1.Value)
                {
                    
                    ListObject sqdList = pltSheet.ListObjects.AddEx(SourceType: XlListObjectSourceType.xlSrcRange, Source: range2, XlListObjectHasHeaders: XlYesNoGuess.xlYes);
                    ListColumn sqdCol = sqdList.ListColumns[1];
                    ListColumn posCol = sqdList.ListColumns.Add();
                    ListColumn statusCol = sqdList.ListColumns.Add();
                    posCol.Name = "Position";
                    statusCol.Name = "Status";
                    sqdCol.Name = keyValuePair.Key;
                    sqdCol.Range[i].Value = keyValuePair.Key;
                    List<ListColumn> siColumns = new List<ListColumn>();
                    foreach (string siName in siDict.Keys)
                    {
                        siColumns.Add(sqdList.ListColumns.Add());
                        siColumns.Last().Name = siName;
                    }
                    foreach(string name in keyValuePair.Value)
                    {
                        sqdCol.Range[i].Value = name;
                        foreach(KeyValuePair<Soldier, KeyValuePair<string, List<SensitiveItemBaseClass>>> keyValuePair2 in soldierWeaponAssignments)
                        {
                            if(name == (keyValuePair2.Key.LastName+","+ keyValuePair2.Key.FirstName))
                            {
                                posCol.Range[i].Value = keyValuePair2.Value.Key;
                                statusCol.Range[i].Value = keyValuePair2.Key.StatusString;
                                foreach (ListColumn siListColumn in siColumns)
                                {
                                    foreach (SensitiveItemBaseClass si in keyValuePair2.Value.Value)
                                    {
                                        if(siListColumn.Name == si.EquipmentName)
                                        {
                                            siListColumn.Range[i].Value = si.SerialNumber;
                                        }
                                    }
                                }
                            }
                        }

                        i++;
                        count++;
                    }
                    i++;
                    count++;
                    range2 = (Range)pltSheet.get_Range("A1" ).Cells[count, 1];
                    i = 2;

                }
            }


            workbook.SaveAs(fileName);
            return 1;
        }
    }
}
