using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ArmySIManagment.BuisnessLogic.Models
{
    enum Rank {E1,E2,E3,E4,E5,E6,E7,E8,E9,W1,W2,W3,W4,W5,O1,O2,O3,O4,O5,O6,O7,O8,O9 };
    enum Platoons { FIRSTPLATOON,SECONDPLATOON,THIRDPLATOON,HQPLATOON};
    
    public class Soldier:BaseModel
    {
        private string _firstName;
        private string _lastName;
        private string _role;
        private double _dodNum;
        private double _rank;
        private double _platoon;
        private SensitiveItemList _assignedSI;
        private string _adminNumber;
        private int _soldierIndex;
        private Dictionary<double, string> _assignedSIDictionary;
        private int _status;
        private string _rankString;
        private string _statusString;


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


        public Soldier ()
        {
            _firstName = "NULL";
            _lastName = "NULL";
            _role = "NULL";
            _dodNum = -1;
            Rank = 1;
            _assignedSI = new SensitiveItemList();
            _assignedSIDictionary = new Dictionary< double,string>();
            Status = 4;
            _platoon = 0;
            SoldierID = -1;

    }

    public int Status
        {
            get
            {
                return _status;
            }
            set
            {
                SetProperty(ref _status, value);
                StatusString = DrillStatus[Status];
            }
        }
        public int SoldierID
        {
            get
            {
                return _soldierIndex;
            }
            set
            {
                SetProperty(ref _soldierIndex, value);
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
                SetProperty(ref _firstName, value);
            }
        }
        public Dictionary<double, string> AssignedSIDictionary
        {
            get
            {
                return _assignedSIDictionary;
            }
            set
            {
                SetProperty(ref _assignedSIDictionary, value);
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
                SetProperty(ref _adminNumber, value);
            }
        }
        public SensitiveItemList AssignedSI
        {
            get
            {
                return _assignedSI;
            }
            set
            {
                SetProperty(ref _assignedSI, value);
            }
        }
        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                SetProperty(ref _role, value);
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
                SetProperty(ref _lastName, value);
            }
        }
        public double DODNum
        {
            get
            {
                return _dodNum;
            }
            set
            {
                SetProperty(ref _dodNum, value);
            }
        }
        public double Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                SetProperty(ref _rank, value);
                RankString = RankDict[Convert.ToInt32(Rank)];
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
            }
        }
        public string RankString
        {
            get
            {
                return _rankString;
            }
            set
            {

                SetProperty(ref _rankString, value);
            }
        }
        
        public string StatusString
        {
            get
            {
                return _statusString;
            }
            set
            {
                SetProperty(ref _statusString, value);
            }
        }


    }
}
