using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using ArmySIManagment.Connectors;
using Caliburn.Micro;
namespace ArmySIManagment.GUI.ViewModels
{
    public class SelectedRoleAddAssignedSIViewModel: Screen
    {
        private BindableCollection<string> _availSITypes;

        private BindableCollection<double> _serialNumbers;
        private BindableCollection<string> _adminNumbers;

        private List<SensitiveItemBaseClass> _sensitiveItems;
        private WeaponAssignments _weaponAssignment;
        private double _selectedSerialNumber;
        private string _selectedAdmindNumber;
        private List<WeaponAssignments> _allWeaponAssignments;
        private Roles _role;
        private List<SensitiveItemBaseClass> _selectedSI;

        public List<SensitiveItemBaseClass> SelectedSI
        {
            get
            {
                return _selectedSI;
            }
            set
            {
                _selectedSI = value;
                NotifyOfPropertyChange(() => SelectedSI);
            }
        }


        public Roles Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                NotifyOfPropertyChange(() => Role);
            }
        }

        public List<WeaponAssignments> AllWeaponAssignments
        {
            get
            {
                return _allWeaponAssignments;
            }
            set
            {
                _allWeaponAssignments = value;
                NotifyOfPropertyChange(() => AllWeaponAssignments);
            }
        }




        public string SelectedAdminNumber
        {
            get
            {
                return _selectedAdmindNumber;
            }
            set
            {
                _selectedAdmindNumber = value;
                NotifyOfPropertyChange(() => SelectedAdminNumber);
            }
        }


        public double SelectedSerialNumber
        {
            get
            {
                return _selectedSerialNumber;
            }
            set
            {
                _selectedSerialNumber = value;
                NotifyOfPropertyChange(() => SelectedSerialNumber);
            }
        }


        public WeaponAssignments WeaponAssignment
        {
            get
            {
                return _weaponAssignment;
            }
            set
            {
                _weaponAssignment = value;
                NotifyOfPropertyChange(() => WeaponAssignment);
            }
        }

        public List<SensitiveItemBaseClass> SensitiveItems
        {
            get
            {
                return _sensitiveItems;
            }
            set
            {
                _sensitiveItems = value;
                NotifyOfPropertyChange(() => SensitiveItems);
            }
        }

        private string _selectedSIType;

        public string SelectedSIType
        {
            get
            {
                return _selectedSIType;
            }
            set
            {
                _selectedSIType = value;
                NotifyOfPropertyChange(() => SelectedSIType);
            }
        }

        public BindableCollection<string> AdminNumbers
        {
            get
            {
                return _adminNumbers;
            }
            set
            {
                _adminNumbers = value;
                NotifyOfPropertyChange(() => AdminNumbers);
            }
        }

        public BindableCollection<double> SerialNumbers
        {
            get
            {
                return _serialNumbers;
            }
            set
            {
                _serialNumbers = value;
                NotifyOfPropertyChange(() => SerialNumbers);
            }
        }

        public BindableCollection<string> AvailSITypes
        {
            get
            {
                return _availSITypes;
            }
            set
            {
                _availSITypes = value;
                NotifyOfPropertyChange(() => AvailSITypes);
            }
        }

        public SelectedRoleAddAssignedSIViewModel(Roles role, WeaponAssignments roleWeaponAssignments, Dictionary<int, string> listOfWeapons, List<SensitiveItemBaseClass> sensitiveItem, List<WeaponAssignments> allWeaponAssignments)
        {

            SelectedSI = new List<SensitiveItemBaseClass>();
            DisplayName = "Assign SI to Role";
            AvailSITypes = new BindableCollection<string>();
            SensitiveItems = sensitiveItem;
            WeaponAssignment = roleWeaponAssignments;
            AllWeaponAssignments = allWeaponAssignments;
            Role = role;
            foreach (KeyValuePair<int,string> keyValuePair in listOfWeapons)
            {
                AvailSITypes.Add(keyValuePair.Value);
            }
        }
        public void ItemTypeSelectionChanged()
        {
            SerialNumbers = new BindableCollection<double>();
            AdminNumbers = new BindableCollection<string>();
            foreach (SensitiveItemBaseClass si in SensitiveItems)
            {
                if(si.EquipmentName == SelectedSIType)
                {
                    SerialNumbers.Add(si.SerialNumber);
                    AdminNumbers.Add(si.RosterNumber);
                }
            }
        }
        public void AdminNumberSelectionChanged()
        {
            foreach(SensitiveItemBaseClass si in SensitiveItems)
            {
                
                if(SelectedAdminNumber == si.RosterNumber  )
                {
                    try
                    {
                        foreach (WeaponAssignments weaponAssignments in AllWeaponAssignments)
                        {
                            foreach (SensitiveItemBaseClass sensitiveItem in weaponAssignments.AssignedSI)
                            {
                                if (sensitiveItem == si)
                                {
                                    throw new System.Exception("SI Item is already Assigned");
                                }
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    if (si.SerialNumber != SelectedSerialNumber)
                    {
                        if (!SelectedSI.Contains(si))
                        {
                            SelectedSI.Add(si);
                            SelectedSerialNumber = si.SerialNumber;
                        }
                    }
                }
            }
        }
        public void SerialNumberSelectionChanged()
        {
            foreach (SensitiveItemBaseClass si in SensitiveItems)
            {
               
                if (SelectedSerialNumber == si.SerialNumber && SelectedAdminNumber != si.RosterNumber)
                {
                    try
                    {
                        foreach (WeaponAssignments weaponAssignments in AllWeaponAssignments)
                        {
                            foreach (SensitiveItemBaseClass sensitiveItem in weaponAssignments.AssignedSI)
                            {
                                if (sensitiveItem == si)
                                {
                                    SelectedSerialNumber = 0;
                                    throw new System.Exception("SI Item is already Assigned");
                                    
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    if (si.RosterNumber != SelectedAdminNumber)
                    {
                        if (!SelectedSI.Contains(si))
                        {
                            
                            SelectedSI.Add(si);
                          
                        }
                        SelectedAdminNumber = si.RosterNumber;
                    }
                }
            }
        }


        public void AddItemBtn()
        {
           
            foreach(SensitiveItemBaseClass si in SelectedSI)
            {
                if (SelectedAdminNumber == si.RosterNumber)
                {
                    WeaponAssignment.AssignedSI.Add(si);
                   
                }
            }
            ArmyDataBaseConnector.SaveWeaponAssignments(WeaponAssignment);
            this.TryClose();
        }
    }
}
