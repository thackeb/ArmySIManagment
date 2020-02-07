using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
namespace ArmySIManagment.GUI.ViewModels
{
    class SelectedSensitiveItemViewModel:Screen
    {
        public Dictionary<int, string> DrillStatus = new Dictionary<int, string>
        {
            {0,"Main Body" },
            {1,"Advon" },
            {2,"Rear" },
            {3,"AWOL" },
            {4,"Absent" }
        };
        private SensitiveItemBaseClass _sensitiveItemBaseClass;

        private WeaponAssignments _weaponAssignments;

        private RoleAssignments _roleAssignments;

        private string _siStatus;

        private string _assignedRole;

        private string _assignedSoldier;

        private int _serialNumber;

        private string _adminNumber;

        private string _status;

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        public string AdminNumber
        {
            get
            {
                return _adminNumber;
            }
            set
            {
                _adminNumber = value;
                NotifyOfPropertyChange(() => AdminNumber);
            }
        }

        public int SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                _serialNumber = value;
                NotifyOfPropertyChange(() => SerialNumber);
            }
        }

        public string AssignedSoldier
        {
            get
            {
                return _assignedSoldier;
            }
            set
            {
                _assignedSoldier = value;
                NotifyOfPropertyChange(() => AssignedSoldier);
            }
        }

        public string AssignedRole
        {
            get
            {
                return _assignedRole;
            }
            set
            {
                _assignedRole = value;
                NotifyOfPropertyChange(() => AssignedRole);
            }
        }

        public string SIStatus
        {
            get
            {
                return _siStatus;
            }
            set
            {
                _siStatus = value;
                NotifyOfPropertyChange(() => SIStatus);
            }
        }


        public RoleAssignments RoleAssignments
        {
            get
            {
                return _roleAssignments;
            }
            set
            {
                _roleAssignments = value;
                NotifyOfPropertyChange(() => RoleAssignments);
                AssignedSoldier = RoleAssignments.AssignedSoldier.LastName + ", " +RoleAssignments.AssignedSoldier.FirstName;
                Status = DrillStatus[RoleAssignments.AssignedSoldier.Status];
            }
        }

        public WeaponAssignments WeaponAssignments
        {
            get
            {
                return _weaponAssignments;
            }
            set
            {
                _weaponAssignments = value;
                NotifyOfPropertyChange(() => WeaponAssignments);
                AssignedRole = WeaponAssignments.Role.RoleName;
            }
        }

        public SensitiveItemBaseClass SensitiveItemBaseClass
        {
            get
            {
                return _sensitiveItemBaseClass;
            }
            set
            {
                _sensitiveItemBaseClass = value;
                NotifyOfPropertyChange(() => SensitiveItemBaseClass);
                SerialNumber = Convert.ToInt32( SensitiveItemBaseClass.SerialNumber);
                AdminNumber = SensitiveItemBaseClass.RosterNumber;

            }
        }

        public SelectedSensitiveItemViewModel(SensitiveItemBaseClass sensitiveItem, WeaponAssignments weaponAssignment, RoleAssignments roleAssignment)
        {
            DisplayName ="SI Information" ;
            if (sensitiveItem != null)
            {
                SensitiveItemBaseClass = sensitiveItem;
            }
            if (weaponAssignment != null)
            {
                WeaponAssignments = weaponAssignment;
                
            }
            if(roleAssignment.Role == weaponAssignment.Role)
            {
                RoleAssignments = roleAssignment;
                if(roleAssignment.AssignedSoldier.Status == 4)
                {
                    SIStatus = "Not Checked Out";
                }
                SIStatus = roleAssignment.AssignedSoldier.StatusString;
            }
            else
            {
                SIStatus = "Not Checked Out";
            }
                
        }
    }
}
