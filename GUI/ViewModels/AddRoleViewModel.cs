using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.Connectors;
using Caliburn.Micro;
namespace ArmySIManagment.GUI.ViewModels
{
    public class AddRoleViewModel : Screen
    {
        private string _roleName;
            
        private int _fireTeamsCheckedCount;

        private List<Roles> _rolesList;

        private WindowManager _windowManager { get; set; }
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



        Dictionary<int, bool> SquadCheckStatus = new Dictionary<int, bool>
        {
            {1,false },
            {2,false },
            {3,false },
            {4,false },
        };
        Dictionary<int, bool> PlatoonCheckStatus = new Dictionary<int, bool>
        {
            {1,false },
            {2,false },
            {3,false },
            {4,false },
        };
        Dictionary<int, bool> FireTeamCheckStatus = new Dictionary<int, bool>
        {
            {1,false },
            {2,false },
        };
        public int FireTeamCheckCount
        {
            get
            {
                return _fireTeamsCheckedCount;
            }
            set
            {
                _fireTeamsCheckedCount = value;
                NotifyOfPropertyChange(() => FireTeamCheckCount);
            }
        }
        private int _squadsCheckedCount;

        public int SquadsCheckCount
        {
            get
            {
                return _squadsCheckedCount;
            }
            set
            {
                _squadsCheckedCount = value;
                NotifyOfPropertyChange(() => SquadsCheckCount);
            }
        }
        private int _platoonCheckedCount;

        public int PlatoonCheckCount
        {
            get
            {
                return _platoonCheckedCount;
            }
            set
            {
                _platoonCheckedCount = value;
                NotifyOfPropertyChange(() => PlatoonCheckCount);
            }
        }


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


        private bool _firstPlatoonCheckBox;
        

        public bool FirstPlatoonCheckBox
        {
            get
            {
                return _firstPlatoonCheckBox;
            }
            set
            {

                PlatoonCheckStatus[1] = value;
               
                _firstPlatoonCheckBox = value;
                NotifyOfPropertyChange(() => FirstPlatoonCheckBox);
            }
        }
        private bool _secondPlatoonCheckBox;

        public bool SecondPlatoonCheckBox
        {
            get
            {
                return _secondPlatoonCheckBox;
            }
            set
            {
                PlatoonCheckStatus[2] = value;
                _secondPlatoonCheckBox = value;
                NotifyOfPropertyChange(() => SecondPlatoonCheckBox);
            }
        }
        private bool _thirdPlatoonCheckBox;

        public bool ThirdPlatoonCheckBox
        {
            get
            {
                return _thirdPlatoonCheckBox;
            }
            set
            {
                PlatoonCheckStatus[3] = value;
                _thirdPlatoonCheckBox = value;
                NotifyOfPropertyChange(() => ThirdPlatoonCheckBox);
            }
        }
        private bool _fourthPlatoonCheckBox;

        public bool FourthPlatoonCheckBox
        {
            get
            {
                return _fourthPlatoonCheckBox;
            }
            set
            {
                PlatoonCheckStatus[4] = value;
                _fourthPlatoonCheckBox = value;
                NotifyOfPropertyChange(() => FourthPlatoonCheckBox);
            }
        }
        private bool _firstSquadCheckBox;

        public bool FirstSquadCheckBox
        {
            get
            {
               
                return _firstSquadCheckBox;
            }
            set
            {
                SquadCheckStatus[1] = value;
                 _firstSquadCheckBox = value;
                NotifyOfPropertyChange(() => FirstSquadCheckBox);
            }
        }
        private bool _secondSquadCheckBox;

        public bool SecondSquadCheckBox
        {
            get
            {
                return _secondSquadCheckBox;
            }
            set
            {
                SquadCheckStatus[2] = value;
                _secondSquadCheckBox = value;
                NotifyOfPropertyChange(() => SecondSquadCheckBox);
            }
        }
        private bool _thirdSquadCheckBox;

        public bool ThirdSquadCheckBox
        {
            get
            {
                return _thirdSquadCheckBox;
            }
            set
            {
                SquadCheckStatus[3] = value;
                _thirdSquadCheckBox = value;
                NotifyOfPropertyChange(() => ThirdSquadCheckBox);
            }
        }
        private bool _fourthSquadCheckBox;

        public bool FourthSquadCheckBox
        {
            get
            {
                return _fourthSquadCheckBox;
            }
            set
            {
                SquadCheckStatus[4] = value;
                _fourthSquadCheckBox = value;
                NotifyOfPropertyChange(() => FourthSquadCheckBox);
            }
        }

        private bool _alphaTeamCheckBox;

        public bool AlphaTeamCheckBox
        {
            get
            {
                return _alphaTeamCheckBox;
            }
            set
            {
                FireTeamCheckStatus[1] = value;
                 _alphaTeamCheckBox = value;
                NotifyOfPropertyChange(() => AlphaTeamCheckBox);
            }
        }

        private bool _bravoTeamCheckBox;

        public bool BravoTeamCheckBox
        {
            get
            {
                return _bravoTeamCheckBox;
            }
            set
            {
                FireTeamCheckStatus[2] = value;
                _bravoTeamCheckBox = value;
                NotifyOfPropertyChange(() => BravoTeamCheckBox);
            }
        }

        public object ArmyDatabaseConnector { get; private set; }

        public AddRoleViewModel(List<Roles> roleList)
        {
            
            DisplayName = "Add Role";
            RoleName = "Enter Role Name Here";
            RolesList = roleList;
            _windowManager = new WindowManager();
        }

        //Does not work, need to update the List somehow
        //TODO
        public void AddRoleBtn ()
        {
            bool fireTeams = false;
            bool squads = false;
            
            foreach (KeyValuePair<int, bool> keyValuePairFireTeam in FireTeamCheckStatus)
            {
                if(keyValuePairFireTeam.Value)
                {
                    fireTeams = true;
                }
            }
            foreach (KeyValuePair<int, bool> keyValuePairFireTeam in SquadCheckStatus)
            {
                if (keyValuePairFireTeam.Value)
                {
                    squads = true;
                }
            }
            foreach (KeyValuePair<int,bool> keyValuePairPlatoon in PlatoonCheckStatus)
            {
                if (keyValuePairPlatoon.Value)
                {
                    if (!squads)
                    {
                        Roles role = new Roles();
                        role.RoleName = RoleName;
                        role.Platoon = keyValuePairPlatoon.Key;
                        role.Squad = 0;
                        role.FireTeam = 0;
                        RolesList.Add(role);
                        ArmyDataBaseConnector.SaveRole(role);
                    }
                    else
                    {

                        foreach (KeyValuePair<int, bool> keyValuePairSquad in SquadCheckStatus)
                        {
                            if (keyValuePairSquad.Value)
                            {
                                if (!fireTeams)
                                {
                                    Roles role = new Roles();
                                    role.RoleName = RoleName;
                                    role.Platoon = keyValuePairPlatoon.Key;
                                    role.FireTeam = 0;
                                    role.Squad = keyValuePairSquad.Key;
                                    RolesList.Add(role);
                                    ArmyDataBaseConnector.SaveRole(role);
                                }
                                else
                                {
                                    foreach (KeyValuePair<int, bool> keyValuePairFireTeam in FireTeamCheckStatus)
                                    {
                                        Roles role = new Roles();
                                        role.RoleName = RoleName;
                                        role.Platoon = keyValuePairPlatoon.Key;
                                        role.Squad = keyValuePairSquad.Key;
                                        if (keyValuePairFireTeam.Value)
                                        {

                                            role.FireTeam = keyValuePairFireTeam.Key;
                                            RolesList.Add(role);
                                            ArmyDataBaseConnector.SaveRole(role);
                                        }
                                        else
                                        {
                                            role.FireTeam = 0;
                                        }

                                    }
                                }
                            }
                            
                        }
                    }
                   
                }
                
            }
            this.TryClose();
        }
        
    }
}
