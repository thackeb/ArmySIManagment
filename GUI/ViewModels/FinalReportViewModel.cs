using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using ArmySIManagment.Connectors;
using Microsoft.Win32;
using System.Security;
using System.IO;
using System.Windows;

namespace ArmySIManagment.GUI.ViewModels
{
    public class FinalReportViewModel : Conductor<Screen>.Collection.AllActive
    {
        private List<Soldier> _soldiers;

        private List<WeaponAssignments> _weaponAssignments;
        private List<RoleAssignments> _roleAssignments;
        private List<Roles> _roles;
        private int _soldierGoingOutCount;
        private int _soldierAwolCount;
        private int _soldierAbsentCount;
        private int _soldierAdvonCount;
        private int _soldierMainBodyCount;
        private int _soldierReadCount;
        private BindableCollection<KeyValuePair<string,int>> _sensitiveItemCount;
        private Dictionary<string,int> _sensitiveItemCountDict;
        private int _companyCount;
        private List<SensitiveItemBaseClass> _sensitiveItemBaseClasses;
        private string _excelSheetFilePath;

        public string ExcelSheetFilePath
        {
            get
            {
                return _excelSheetFilePath;
            }
            set
            {
                _excelSheetFilePath = value;
                NotifyOfPropertyChange(() => ExcelSheetFilePath);
            }
        }

        public List<SensitiveItemBaseClass> SensitiveItemBaseClasses
        {
            get
            {
                return _sensitiveItemBaseClasses;
            }
            set
            {
                _sensitiveItemBaseClasses = value;
                NotifyOfPropertyChange(() => SensitiveItemBaseClasses);
            }
        }


        public int CompanyCount
        {
            get
            {
                return _companyCount;
            }
            set
            {
                _companyCount = value;
                NotifyOfPropertyChange(() => CompanyCount);
            }
        }


        public Dictionary<string,int> SensitiveItemCountDict
        {
            get
            {
                return _sensitiveItemCountDict;
            }
            set
            {
                _sensitiveItemCountDict = value;
                NotifyOfPropertyChange(() => SensitiveItemCountDict);
            }
        }

        public BindableCollection<KeyValuePair<string,int>> SensitiveItemCount
        {
            get
            {
                return _sensitiveItemCount;
            }
            set
            {
                _sensitiveItemCount = value;
                NotifyOfPropertyChange(() => SensitiveItemCount);
            }
        }

        public int SoldierRearCount
        {
            get
            {
                return _soldierReadCount;
            }
            set
            {
                _soldierReadCount = value;
                NotifyOfPropertyChange(() => SoldierRearCount);
            }
        }

        public int SoldierMainBodyCount
        {
            get
            {
                return _soldierMainBodyCount;
            }
            set
            {
                _soldierMainBodyCount = value;
                NotifyOfPropertyChange(() => SoldierMainBodyCount);
            }
        }

        public int SoldierADVONCount
        {
            get
            {
                return _soldierAdvonCount;
            }
            set
            {
                _soldierAdvonCount = value;
                NotifyOfPropertyChange(() => SoldierADVONCount);
            }
        }

        public int SoldierAbsentCount
        {
            get
            {
                return _soldierAbsentCount;
            }
            set
            {
                _soldierAbsentCount = value;
                NotifyOfPropertyChange(() => SoldierAbsentCount);
            }
        }

        public int SoldierAWOLCount
        {
            get
            {
                return _soldierAwolCount;
            }
            set
            {
                _soldierAwolCount = value;
                NotifyOfPropertyChange(() => SoldierAWOLCount);
            }
        }

        public int SoldierGoingOutCount
        {
            get
            {
                return _soldierGoingOutCount;
            }
            set
            {
                _soldierGoingOutCount = value;
                NotifyOfPropertyChange(() => SoldierGoingOutCount);
            }
        }


        public List<Roles> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
                NotifyOfPropertyChange(() => Roles);
            }
        }

        public List<RoleAssignments> RoleAssignments
        {
            get
            {
                return _roleAssignments;
            }
            set
            {
                _roleAssignments = value;
                NotifyOfPropertyChange(() => RoleAssignments);
            }
        }

        public List<WeaponAssignments> WeaponAssignments
        {
            get
            {
                return _weaponAssignments;
            }
            set
            {
                _weaponAssignments = value;
                NotifyOfPropertyChange(() => WeaponAssignments);
            }
        }

        public List<Soldier> Soldiers
        {
            get
            {
                return _soldiers;
            }
            set
            {
                _soldiers = value;
                NotifyOfPropertyChange(() => Soldiers);
            }
        }

        public FinalReportViewModel(List<Soldier> soldiers, List <SensitiveItemBaseClass> sensitiveItemBaseClasses, List<WeaponAssignments> weaponAssignments, List<Roles> roles, List<RoleAssignments> roleAssignments)
        {
            this.Activated += FinalReportViewModel_Activated;
            
            DisplayName = "Status of Company";
            Soldiers = soldiers;
            WeaponAssignments = weaponAssignments;
            Roles = roles;
            RoleAssignments = roleAssignments;
            SensitiveItemCountDict = new Dictionary<string, int>();
            SoldierRearCount = 0;
            SoldierADVONCount = 0;
            SoldierMainBodyCount = 0;
            SoldierAbsentCount = 0;
            SoldierGoingOutCount = 0;
            CompanyCount = Soldiers.Count;
            SensitiveItemBaseClasses = sensitiveItemBaseClasses;
            //Figure out how many types of SI there and how many are going
            foreach (SensitiveItemBaseClass sensitiveItemBaseClass in SensitiveItemBaseClasses)
            {
                if(!SensitiveItemCountDict.ContainsKey(sensitiveItemBaseClass.EquipmentName))
                {
                    SensitiveItemCountDict.Add(sensitiveItemBaseClass.EquipmentName, 0);
                }
                foreach(WeaponAssignments weaponAssignments1 in WeaponAssignments)
                {
                    if (weaponAssignments1.AssignedSI.Contains(sensitiveItemBaseClass))
                    {
                        foreach(RoleAssignments roleAssignments1 in RoleAssignments)
                        {
                            if(weaponAssignments1.Role == roleAssignments1.Role)
                            {
                                switch(roleAssignments1.AssignedSoldier.Status)
                                {
                                    case 0: //Main Body
                                        {
                                            SensitiveItemCountDict[sensitiveItemBaseClass.EquipmentName]++; 
                                        }
                                        break;
                                    case 1: //Advon
                                        {
                                            SensitiveItemCountDict[sensitiveItemBaseClass.EquipmentName]++;
                                        }
                                        break;
                                    case 2: //Rear
                                        {
                                            //Idk
                                        }break;
                                    case 3://Awol
                                        {
                                            //Idk
                                        }break;
                                    case 4://Absent
                                        {
                                            //Idk
                                        }break;
                                    default://Fuck
                                        {
                                            //idk
                                        }break;
                                }
                            }
                        }
                    }
                }
            }

            SensitiveItemCount = new BindableCollection<KeyValuePair<string, int>>(SensitiveItemCountDict);

            foreach(Soldier soldier in Soldiers)
            {
                switch (soldier.Status)
                {
                    case 0: //Main Body
                        {
                            SoldierMainBodyCount++;
                        }
                        break;
                    case 1: //Advon
                        {
                            SoldierADVONCount++;
                        }
                        break;
                    case 2: //Rear
                        {
                            SoldierRearCount++;
                        }
                        break;
                    case 3://Awol
                        {
                            SoldierAWOLCount++;
                        }
                        break;
                    case 4://Absent
                        {
                            SoldierAbsentCount++;
                        }
                        break;
                    default://Fuck
                        {
                            //idk
                        }
                        break;
                }
            }
            SoldierGoingOutCount = SoldierMainBodyCount + SoldierADVONCount + SoldierRearCount;
        }

        private void FinalReportViewModel_Activated(object sender, ActivationEventArgs e)
        {
            SoldierRearCount = 0;
            SoldierADVONCount = 0;
            SoldierMainBodyCount = 0;
            SoldierAbsentCount = 0;
            SoldierGoingOutCount = 0;
            CompanyCount = Soldiers.Count;
            //Figure out how many types of SI there and how many are going
            foreach (SensitiveItemBaseClass sensitiveItemBaseClass in SensitiveItemBaseClasses)
            {
                if (!SensitiveItemCountDict.ContainsKey(sensitiveItemBaseClass.EquipmentName))
                {
                    SensitiveItemCountDict.Add(sensitiveItemBaseClass.EquipmentName, 0);
                }
                foreach (WeaponAssignments weaponAssignments1 in WeaponAssignments)
                {
                    if (weaponAssignments1.AssignedSI.Contains(sensitiveItemBaseClass))
                    {
                        foreach (RoleAssignments roleAssignments1 in RoleAssignments)
                        {
                            if (weaponAssignments1.Role == roleAssignments1.Role)
                            {
                                switch (roleAssignments1.AssignedSoldier.Status)
                                {
                                    case 0: //Main Body
                                        {
                                            SensitiveItemCountDict[sensitiveItemBaseClass.EquipmentName]++;
                                        }
                                        break;
                                    case 1: //Advon
                                        {
                                            SensitiveItemCountDict[sensitiveItemBaseClass.EquipmentName]++;
                                        }
                                        break;
                                    case 2: //Rear
                                        {
                                            //Idk
                                        }
                                        break;
                                    case 3://Awol
                                        {
                                            //Idk
                                        }
                                        break;
                                    case 4://Absent
                                        {
                                            //Idk
                                        }
                                        break;
                                    default://Fuck
                                        {
                                            //idk
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            SensitiveItemCount = new BindableCollection<KeyValuePair<string, int>>(SensitiveItemCountDict);

            foreach (Soldier soldier in Soldiers)
            {
                switch (soldier.Status)
                {
                    case 0: //Main Body
                        {
                            SoldierMainBodyCount++;
                        }
                        break;
                    case 1: //Advon
                        {
                            SoldierADVONCount++;
                        }
                        break;
                    case 2: //Rear
                        {
                            SoldierRearCount++;
                        }
                        break;
                    case 3://Awol
                        {
                            SoldierAWOLCount++;
                        }
                        break;
                    case 4://Absent
                        {
                            SoldierAbsentCount++;
                        }
                        break;
                    default://Fuck
                        {
                            //idk
                        }
                        break;
                }
            }
            SoldierGoingOutCount = SoldierMainBodyCount + SoldierADVONCount + SoldierRearCount;
        }
        public void RefreshBtn()
        {
            SoldierRearCount = 0;
            SoldierADVONCount = 0;
            SoldierMainBodyCount = 0;
            SoldierAbsentCount = 0;
            SoldierGoingOutCount = 0;
            CompanyCount = Soldiers.Count;
            //Figure out how many types of SI there and how many are going
            foreach (SensitiveItemBaseClass sensitiveItemBaseClass in SensitiveItemBaseClasses)
            {
                if (!SensitiveItemCountDict.ContainsKey(sensitiveItemBaseClass.EquipmentName))
                {
                    SensitiveItemCountDict.Add(sensitiveItemBaseClass.EquipmentName, 0);
                }
                foreach (WeaponAssignments weaponAssignments1 in WeaponAssignments)
                {
                    if (weaponAssignments1.AssignedSI.Contains(sensitiveItemBaseClass))
                    {
                        foreach (RoleAssignments roleAssignments1 in RoleAssignments)
                        {
                            if (weaponAssignments1.Role == roleAssignments1.Role)
                            {
                                switch (roleAssignments1.AssignedSoldier.Status)
                                {
                                    case 0: //Main Body
                                        {
                                            SensitiveItemCountDict[sensitiveItemBaseClass.EquipmentName]++;
                                        }
                                        break;
                                    case 1: //Advon
                                        {
                                            SensitiveItemCountDict[sensitiveItemBaseClass.EquipmentName]++;
                                        }
                                        break;
                                    case 2: //Rear
                                        {
                                            //Idk
                                        }
                                        break;
                                    case 3://Awol
                                        {
                                            //Idk
                                        }
                                        break;
                                    case 4://Absent
                                        {
                                            //Idk
                                        }
                                        break;
                                    default://Fuck
                                        {
                                            //idk
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            SensitiveItemCount = new BindableCollection<KeyValuePair<string, int>>(SensitiveItemCountDict);

            foreach (Soldier soldier in Soldiers)
            {
                switch (soldier.Status)
                {
                    case 0: //Main Body
                        {
                            SoldierMainBodyCount++;
                        }
                        break;
                    case 1: //Advon
                        {
                            SoldierADVONCount++;
                        }
                        break;
                    case 2: //Rear
                        {
                            SoldierRearCount++;
                        }
                        break;
                    case 3://Awol
                        {
                            SoldierAWOLCount++;
                        }
                        break;
                    case 4://Absent
                        {
                            SoldierAbsentCount++;
                        }
                        break;
                    default://Fuck
                        {
                            //idk
                        }
                        break;
                }
            }
            SoldierGoingOutCount = SoldierMainBodyCount + SoldierADVONCount + SoldierRearCount;
        }

        public void SelectFileBtn()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            try
            {
                ExcelSheetFilePath = openFileDialog1.FileName;
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Can not open an Excel Sheet while it is in use by another program");
            }
        }
        public void ExportExcelBtn()
        {
            if (ExcelSheetFilePath != "")
            {
                ArmySIExcelSheet armySIExcelSheet = new ArmySIExcelSheet();
                int ret = armySIExcelSheet.ExportSISheet(ExcelSheetFilePath, Soldiers, WeaponAssignments, Roles, RoleAssignments, SensitiveItemBaseClasses);
                if(ret ==1)
                {
                    MessageBox.Show("Exported Excel Sheet to " + ExcelSheetFilePath);
                }
            }
        }
    }
}
