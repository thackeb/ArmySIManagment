using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using ArmySIManagment.Connectors;
using Caliburn.Micro;
namespace ArmySIManagment.GUI.ViewModels
{
    public class SelectedSoldierInfoViewModel : Conductor<Screen>.Collection.AllActive
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
        private string _lastName;

        private string _firstName;

        private string _selectedPosition;

        private WeaponAssignments _weaponAssignments;

        private BindableCollection<SensitiveItemBaseClass> _sensitiveItemBaseClasses;

        private List<string> _statuses;

        private List<string >_rank;

        private List<RoleAssignments> _positions;

        

        private string _platoon;

        private string _selectedRank;

        private string _selectedStatus;
        private Soldier _soldier;
        private RoleAssignments _selectedRole;
        private string _fireTeam;
        private string _squad;
        private string _selectedRoleName;
        private List<RoleAssignments> _roleAssignments;
        private List<Roles> _roles;
        private WindowManager WindowManager { get; set; }
        private SelectedSoldierAssignRoleTabControlViewModel _selectedSoldierAssignRoleTabControlViewModel;
        private List<WeaponAssignments> _allWeaponAssignments;

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


        public string SelectedRoleName
        {
            get
            {
                return _selectedRoleName;
            }
            set
            {
                _selectedRoleName = value;
                NotifyOfPropertyChange(() => SelectedRoleName);
            }
        }


        public string Squad
        {
            get
            {
                return _squad;
            }
            set
            {
                _squad = value;
                NotifyOfPropertyChange(() => Squad); 
            }
        }


        public string FireTeam
        {
            get
            {
                return _fireTeam;
            }
            set
            {
                _fireTeam = value;
                NotifyOfPropertyChange(() => FireTeam);
            }
        }


        public RoleAssignments SelectedRole
        {
            get
            {
                return _selectedRole;
            }
            set
            {
                _selectedRole = value;
                NotifyOfPropertyChange(() => SelectedRole);
                if (SelectedRole != null)
                {
                    Platoon = SelectedRole.Role.PlatoonString;
                    Squad = SelectedRole.Role.SquadString;
                    FireTeam = SelectedRole.Role.FireTeamString;
                    SelectedRoleName = SelectedRole.Role.RoleName;
                }
            }
        }


        public Soldier Soldier
        {
            get
            {
                return _soldier;
            }
            set
            {
                _soldier = value;
                NotifyOfPropertyChange(() => Soldier);
                if (Soldier != null)
                {
                    FirstName = Soldier.FirstName;
                    LastName = Soldier.LastName;
                    SelectedRank = RankDict[Convert.ToInt32(Soldier.Rank)];
                }
                
                
            }
        }


        public List<RoleAssignments> Positions
        {
            get
            {
                return _positions;
            }
            set
            {
                _positions = value;
                NotifyOfPropertyChange(() => Positions);
            }
        }
        public string SelectedStatus
        {
            get
            {
                return _selectedStatus;
            }
            set
            {
                _selectedStatus = value;
                NotifyOfPropertyChange(() => SelectedStatus);
            }
        }

        public string SelectedRank
        {
            get
            {
                return _selectedRank;
            }
            set
            {
                _selectedRank = value;
                NotifyOfPropertyChange(() => SelectedRank);
            }
        }


        public string Platoon
        {
            get
            {
                return _platoon;
            }
            set
            {
                _platoon = value;
                NotifyOfPropertyChange(() => Platoon);
            }
        }


        public List<string> Rank
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


        public List<string> Statuses
        {
            get
            {
                return _statuses;
            }
            set
            {
                _statuses = value;
                NotifyOfPropertyChange(() => Statuses);
            }
        }


        public BindableCollection<SensitiveItemBaseClass> SensitiveItemBaseClasses
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
                if (WeaponAssignments != null)
                {
                    SensitiveItemBaseClasses = new BindableCollection<SensitiveItemBaseClass>(WeaponAssignments.AssignedSI);
                }
            }
        }

        public string SelectedPosition
        {
            get
            {
                return _selectedPosition;
            }
            set
            {
                _selectedPosition = value;
                NotifyOfPropertyChange(() => SelectedPosition);
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

        public SelectedSoldierInfoViewModel(Soldier soldier,List<WeaponAssignments> weaponAssignments, List<RoleAssignments> roleAssignments, List<Roles> roles)
        {
            if (soldier != null)
            {
                WindowManager = new WindowManager();
                DisplayName = "Soldier Information";
                Soldier = soldier;
                Rank = new List<string>();
                AllWeaponAssignments = weaponAssignments;
                foreach (KeyValuePair<int, string> keyValuePair in RankDict)
                {
                    Rank.Add(keyValuePair.Value);
                }

                Positions = roleAssignments;
                foreach (RoleAssignments roleAssignments1 in roleAssignments)
                {
                    if (soldier == roleAssignments1.AssignedSoldier)
                    {
                        SelectedRole = roleAssignments1;
                        break;
                    }
                }
                if (SelectedRole == null)
                {
                    SelectedRole = new RoleAssignments();
                }
                else
                {
                    foreach (WeaponAssignments weaponAssignments1 in weaponAssignments)
                    {
                        if (weaponAssignments1.Role == SelectedRole.Role)
                        {
                            WeaponAssignments = weaponAssignments1;
                            break;
                        }
                    }
                }

                RoleAssignments = roleAssignments;
                Roles = roles;
                Statuses = new List<string>();
                foreach (KeyValuePair<int, string> keyValuePair1 in DrillStatus)
                {
                    Statuses.Add(keyValuePair1.Value);
                }
                SelectedStatus = Soldier.StatusString;
            }
        }
        public void SelectPositionBtn ()
        {
            if(Roles != null)
            {
                SelectedSoldierAssignRoleTabControlViewModel = new SelectedSoldierAssignRoleTabControlViewModel(Soldier, RoleAssignments, Roles);
                SelectedSoldierAssignRoleTabControlViewModel.Deactivated += SelectedSoldierAssignRoleTabControlViewModel_Deactivated;
                WindowManager.ShowWindow(SelectedSoldierAssignRoleTabControlViewModel);
            }
        }

        private void SelectedSoldierAssignRoleTabControlViewModel_Deactivated(object sender, DeactivationEventArgs e)
        {
            if (RoleAssignments.Count() > 0)
            {
                if (RoleAssignments.Last().AssignedSoldier == Soldier)
                {
                    Platoon = RoleAssignments.Last().Role.PlatoonString;
                    Squad= RoleAssignments.Last().Role.SquadString;
                    FireTeam = RoleAssignments.Last().Role.FireTeamString;
                    SensitiveItemBaseClasses = new BindableCollection<SensitiveItemBaseClass>();
                    SelectedRoleName = RoleAssignments.Last().Role.RoleName;
                    foreach (WeaponAssignments weaponAssignments in AllWeaponAssignments)
                    {
                        if (weaponAssignments.Role == RoleAssignments.Last().Role)
                        {
                            foreach (SensitiveItemBaseClass sensitiveItemBaseClass in weaponAssignments.AssignedSI)
                            {
                                SensitiveItemBaseClasses.Add(sensitiveItemBaseClass);
                            }
                        }
                    }
                }
            }
        }

        public void RemovePositionBtn()
        {
            RoleAssignments.Remove(SelectedRole);
            SelectedRoleName = "";
        }
        public void SaveBtn()
        {
            Soldier.FirstName = FirstName;
            Soldier.LastName = LastName;
            Soldier.Rank = RankDictRev[SelectedRank];
            Soldier.Status = DrillStatusRev[SelectedStatus];
            ArmyDataBaseConnector.SaveSoldierInfo(Soldier);
        }
    }
}
