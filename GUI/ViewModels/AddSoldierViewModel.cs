using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using ArmySIManagment.Connectors;

namespace ArmySIManagment.GUI.ViewModels
{
    public class AddSoldierViewModel : Conductor<Screen>
    {
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
        private WindowManager WindowManager { get; set; }
      
        private string _lastName;
        private string _firstName;
        private string _rank;
        private BindableCollection<string> _ranks;
        private List<Soldier> _soldiers;
        private List<Roles> _roles;
        private List<WeaponAssignments> _weaponAssignments;
        private List<RoleAssignments> _roleAssignments;
        private Soldier _newSoldier;
        private RoleAssignments _roleAssignment;
        private SelectedSoldierAssignRoleTabControlViewModel _selectedSoldierAssignRoleTabControlViewModel;
        private string _assignedRole;

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

        public SelectedSoldierAssignRoleTabControlViewModel SelectedSoldierAssignRoleTabControlViewModel
        {
            get
            {
                return _selectedSoldierAssignRoleTabControlViewModel;
            }
            set
            {
                _selectedSoldierAssignRoleTabControlViewModel = value;
                NotifyOfPropertyChange(() => SelectedSoldierAssignRoleTabControlViewModel);
            }
        }

        public RoleAssignments RoleAssignment
        {
            get
            {
                return _roleAssignment;
            }
            set
            {
                _roleAssignment = value;
                NotifyOfPropertyChange(() => RoleAssignment);
            }
        }


        public Soldier NewSoldier
        {
            get
            {
                return _newSoldier;
            }
            set
            {
                _newSoldier = value;
                NotifyOfPropertyChange(() => NewSoldier);
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




        public BindableCollection<string> Ranks
        {
            get
            {
                return _ranks;
            }
            set
            {
                _ranks = value;
                NotifyOfPropertyChange(() => Ranks);
            }
        }

        public string Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                _rank = value;
                NotifyOfPropertyChange(() => Rank);
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public AddSoldierViewModel(List<Soldier> soldiers, List<RoleAssignments> roleAssignments, List<Roles> roles, List<WeaponAssignments> weaponAssignments)
        {
            Soldiers = soldiers;
            RoleAssignments = roleAssignments;
            WeaponAssignments = weaponAssignments;
            Roles = roles;
            NewSoldier = new Soldier();
            WindowManager = new WindowManager();
            Ranks = new BindableCollection<string>();
            foreach(KeyValuePair<int,string> keyValuePair in RankDict)
            {
                Ranks.Add(keyValuePair.Value);
            }
        }

        public void AssignRoleBtn()
        {
            SelectedSoldierAssignRoleTabControlViewModel = new SelectedSoldierAssignRoleTabControlViewModel(NewSoldier, RoleAssignments, Roles);
            WindowManager.ShowWindow(SelectedSoldierAssignRoleTabControlViewModel);
            SelectedSoldierAssignRoleTabControlViewModel.Deactivated += SelectedSoldierAssignRoleTabControlViewModel_Deactivated;
        }

        private void SelectedSoldierAssignRoleTabControlViewModel_Deactivated(object sender, DeactivationEventArgs e)
        {
            if (RoleAssignments.Last().AssignedSoldier == NewSoldier)
            {
                AssignedRole = RoleAssignments.Last().Role.RoleName;
            }
           
        }

        public void CreateSoldierBtn()
        {
            if (LastName != "" && FirstName != "" && Rank != "")
            {
                NewSoldier.FirstName = FirstName;
                NewSoldier.LastName = LastName;
                NewSoldier.Rank = RankDictRev[Rank];
                Soldiers.Add(NewSoldier);
                ArmyDataBaseConnector.SaveSoldierInfo(NewSoldier);
               this.TryClose();
                
            }
        }

    }
}
