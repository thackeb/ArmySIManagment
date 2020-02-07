using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmySIManagment.BuisnessLogic.Models
{
    
    public class Roles : BaseModel
    {
        public Dictionary<int, string> FireTeamDict = new Dictionary<int, string>
        {
            {0,"None" },
            {1,"Alpha Team" },
            {2,"Bravo Team" }
        };
        public Dictionary<int, string> SquadDict = new Dictionary<int, string>
        {
            {0,"HQ" },
            {1,"1st" },
            {2,"2nd" },
            {3,"3rd" },
            {4,"WPNs" },
        };
        public Dictionary<int, string> PlatoonDict = new Dictionary<int, string>
        {
            {0,"HQ" },
            {1,"1st" },
            {2,"2nd" },
            {3,"3rd" },
            {4,"HQ" },
        };


        private string _roleName;
        private double _platoon;
        private int _roleId;
        private int _squad;
        private int _fireTeam;
        private string _squadString;
        private string _platoonString;

        public string PlatoonString
        {
            get
            {
                return _platoonString;
            }
            set
            {
                
                SetProperty(ref _platoonString, value);
            }
        }


        public string SquadString
        {
            get
            {
                return _squadString;
            }
            set
            {
                SetProperty(ref _squadString, value);
            }
        }


        private string _fireTeamString;

        public string FireTeamString
        {
            get
            {
                return _fireTeamString;
            }
            set
            {
                SetProperty(ref _fireTeamString, value);
            }
        }


        public int FireTeam
        {
            get
            {
                return _fireTeam;
            }
            set
            {
                SetProperty(ref _fireTeam, value);
                FireTeamDict.TryGetValue(value, out string FireTeamStringTmp);
                FireTeamString = FireTeamStringTmp;
            }
        }


        public int Squad
        {
            get
            {
                return _squad;
            }
            set
            {
                SetProperty(ref _squad, value);
                SquadDict.TryGetValue(value, out string SquadStringTmp);
                SquadString = SquadStringTmp;
            }
        }

        public int RoleID
        {
            get
            {
                return _roleId;
            }
            set
            {
                SetProperty(ref _roleId, value);
                
            }
        }

        public double Platoon
        {
            get
            {
                return _platoon;
            }
            set
            {
                SetProperty(ref _platoon, value);
                PlatoonDict.TryGetValue(Convert.ToInt32( value), out string PlatoonStringTmp);
                PlatoonString = PlatoonStringTmp;
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
                SetProperty(ref _roleName, value);
            }
        }

    }
}
