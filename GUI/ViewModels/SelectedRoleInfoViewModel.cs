using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using Caliburn.Micro;
namespace ArmySIManagment.GUI.ViewModels
{
    public class SelectedRoleInfoViewModel:Screen
    {
        private Roles _role;

        private BindableCollection<string> _platoons;

        private WindowManager _windowManager { get; set; }


        private BindableCollection<SensitiveItemBaseClass> _assignedSI;

        private List<SensitiveItemBaseClass> _listOfAllSi;


        private List<WeaponAssignments> _allWeaponAssignments;

        private WeaponAssignments _roleWeaponAssignment;
        private SensitiveItemBaseClass _selectedSIAssignment;

        private List<Soldier> _soldiers;
        private Soldier _assignedSoldier;
        private RoleAssignments _roleAssignment;
        private String _assignedSoldierName;
        private List<RoleAssignments> _roleAssignments;

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


        public String AssignedSoldierName
        {
            get
            {
                return _assignedSoldierName;
            }
            set
            {
                _assignedSoldierName = value;
                NotifyOfPropertyChange(() => AssignedSoldierName);
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
                AssignedSoldier = RoleAssignment.AssignedSoldier;
            }
        }


        public Soldier AssignedSoldier
        {
            get
            {
                return _assignedSoldier;
            }
            set
            {
                _assignedSoldier = value;
                NotifyOfPropertyChange(() => AssignedSoldier);
                AssignedSoldierName = AssignedSoldier.LastName + ", " + AssignedSoldier.FirstName;
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
                _soldiers= value;
                NotifyOfPropertyChange(() => Soldiers);
            }
        }

        public SensitiveItemBaseClass SelectedSIAssignment
        {
            get
            {
                return _selectedSIAssignment;
            }
            set
            {
                _selectedSIAssignment = value;
                NotifyOfPropertyChange(() => SelectedSIAssignment);
            }
        }

        public WeaponAssignments RoleWeaponAssignment
        {
            get
            {
                return _roleWeaponAssignment;
            }
            set
            {
                _roleWeaponAssignment = value;
                NotifyOfPropertyChange(() => RoleWeaponAssignment);
                AssignedSI = new BindableCollection<SensitiveItemBaseClass> (RoleWeaponAssignment.AssignedSI);
            }
        }

        public List<WeaponAssignments> AllWeaponAssignemnts
        {
            get
            {
                return _allWeaponAssignments;
            }
            set
            {
                _allWeaponAssignments = value;
            }
        }


        public List<SensitiveItemBaseClass> ListOfAllSI
        {
            get
            {
                return _listOfAllSi;
            }
            set
            {
                _listOfAllSi = value;
                NotifyOfPropertyChange(() => ListOfAllSI);
            }
        }


        public BindableCollection<SensitiveItemBaseClass> AssignedSI
        {
            get
            {
                return _assignedSI;
            }
            set
            {
                _assignedSI = value;
                NotifyOfPropertyChange(() => AssignedSI);
            }
        }


        private SelectedRoleAddAssignedSIViewModel _selectedRoleAddAssignedSIViewModel;

        public SelectedRoleAddAssignedSIViewModel SelectedRoleAddAssignedSIViewModel
        {
            get
            {
                return _selectedRoleAddAssignedSIViewModel;
            }
            set
            {
                _selectedRoleAddAssignedSIViewModel = value;
                NotifyOfPropertyChange(() => SelectedRoleAddAssignedSIViewModel);
            }
        }


        public BindableCollection<string> Platoons
        {
            get
            {
                return _platoons;
            }
            set
            {
                _platoons = value;
                NotifyOfPropertyChange(() => Platoons);
            }
        }

        private BindableCollection<string> _squads;

        public BindableCollection<string> Squads
        {
            get
            {
                return _squads;
            }
            set
            {
                _squads = value;
                NotifyOfPropertyChange(() => Squads);
            }
        }

        private BindableCollection<string> _fireTeams;

        public BindableCollection<string> FireTeams
        {
            get
            {
                return _fireTeams;
            }
            set
            {
                _fireTeams = value;
                NotifyOfPropertyChange(() => FireTeams);
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

        private string _roleName;

        public string RoleName
        {
            get
            {
                return _roleName;
            }
            set
            {
                _roleName = value;
                NotifyOfPropertyChange(() => RoleName);
            }
        }

        private string _squad;

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

        private string _platoon;

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

        private string _fireTeam;

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

        private Dictionary<int,string> _listOfSITypes;

        public Dictionary<int,string> ListOfSITypes
        {
            get
            {
                return _listOfSITypes;
            }
            set
            {
                _listOfSITypes = value;
                NotifyOfPropertyChange(() => ListOfSITypes);
            }
        }



        public SelectedRoleInfoViewModel(Roles role, List<WeaponAssignments> weaponAssignments, Dictionary<int, string> listOfWeapons, List<SensitiveItemBaseClass> sensitiveItem, List<Soldier> listOfSoldiers, List<RoleAssignments> roleAssignments)
        {
            DisplayName = "Selected Role Information";
            _windowManager = new WindowManager();
            if (role == null)
            {

            }
            else
            {
                Role = role;
                RoleName = role.RoleName;
                Squad = role.SquadString;
                Platoon = role.PlatoonString;
                FireTeam = role.FireTeamString;
                Platoons = new BindableCollection<string>();
                AssignedSI = new BindableCollection<SensitiveItemBaseClass>();
                ListOfAllSI = sensitiveItem.ToList();
                ListOfSITypes = listOfWeapons;
                AllWeaponAssignemnts = weaponAssignments;
                Soldiers = listOfSoldiers;
                RoleAssignments = roleAssignments;
                foreach(RoleAssignments roles in RoleAssignments)
                {
                    if(roles.Role == Role)
                    {
                        AssignedSoldier = roles.AssignedSoldier;
                        break;
                    }
                }
                foreach (KeyValuePair<int,string>  keyValuePair in role.PlatoonDict)
                {
                    Platoons.Add(keyValuePair.Value);
                }
                Squads = new BindableCollection<string>();
                foreach (KeyValuePair<int, string> keyValuePair in role.SquadDict)
                {
                    Squads.Add(keyValuePair.Value);
                }
                FireTeams = new BindableCollection<string>();
                foreach (KeyValuePair<int, string> keyValuePair in role.FireTeamDict)
                {
                    FireTeams.Add(keyValuePair.Value);
                }

                foreach (WeaponAssignments siAssignments in weaponAssignments )
                {
                    if(siAssignments.Role.Equals(role))
                    {
                        RoleWeaponAssignment = siAssignments;
                    }
                }

            }
        }

        public void SaveChangesBtn ()
        {
            Role.RoleName = RoleName;
            Role.SquadString = Squad;
            foreach(KeyValuePair<int,string> keyValuePair in Role.SquadDict)
            {
                if (keyValuePair.Value == Squad)
                {
                    Role.Squad = keyValuePair.Key;
                    break;
                }
            }
            Role.FireTeamString = FireTeam;
            foreach (KeyValuePair<int, string> keyValuePair in Role.FireTeamDict)
            {
                if (keyValuePair.Value == FireTeam)
                {
                    Role.FireTeam = keyValuePair.Key;
                    break;
                }
            }
            foreach (KeyValuePair<int, string> keyValuePair in Role.PlatoonDict)
            {
                if (keyValuePair.Value == Platoon)
                {
                    Role.Platoon = keyValuePair.Key;
                    break;
                }
            }
            
        }
        public void AddSIBtn()
        {
            if(RoleWeaponAssignment == null)
            {
                RoleWeaponAssignment = new WeaponAssignments();
                RoleWeaponAssignment.Role = Role;
                AllWeaponAssignemnts.Add(RoleWeaponAssignment);
            }
            SelectedRoleAddAssignedSIViewModel = new SelectedRoleAddAssignedSIViewModel(Role, RoleWeaponAssignment  , ListOfSITypes,ListOfAllSI, AllWeaponAssignemnts);
            _windowManager.ShowWindow(SelectedRoleAddAssignedSIViewModel);
            SelectedRoleAddAssignedSIViewModel.Deactivated += SelectedRoleAddAssignedSIViewModel_Deactivated;
        }

        private void SelectedRoleAddAssignedSIViewModel_Deactivated(object sender, DeactivationEventArgs e)
        {
            AssignedSI = new BindableCollection<SensitiveItemBaseClass>(RoleWeaponAssignment.AssignedSI);
        }

        public void RemoveSIBtn()
        {
            if (SelectedSIAssignment != null)
            {
                List<SensitiveItemBaseClass> indexOfItemsToRemove = new List<SensitiveItemBaseClass>();
            
                foreach (SensitiveItemBaseClass assignedSI in RoleWeaponAssignment.AssignedSI)
                {
                    if (assignedSI.RosterNumber == SelectedSIAssignment.RosterNumber)
                    {
                        indexOfItemsToRemove.Add(assignedSI);
                    }
                   
                }
                foreach(SensitiveItemBaseClass index in indexOfItemsToRemove)
                {
                    RoleWeaponAssignment.AssignedSI.Remove(index);
                }
                AssignedSI = new BindableCollection<SensitiveItemBaseClass>(RoleWeaponAssignment.AssignedSI);
            }
        }
    }
}
