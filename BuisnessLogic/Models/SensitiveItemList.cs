
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmySIManagment.BuisnessLogic.Models
{

    public class SensitiveItemList : BaseModel
    {
     public  Dictionary<int, string> SensitiveItemDict= new Dictionary<int, string>
        {
            { 0,"M4" },
            { 1,"M-9" },
            { 2,"M249" },
            { 3,"M500" },
            { 4,"M240" },
            {5,"ACOG" },
            {6,"PEQ2" },
            {7,"PEQ15" },
            {8,"PVS14" },
            {9,"MBITR" },
            {10,"ASIP" },

        };

        private List<ACOG> _acogs;
        private List<Asip> _asip;
        private List<CCO> _cco;
        private List<M145> _m145;
        private List<M240B> _m240b;
        private List<M249> _m249;
        private List<M320A1> _m320a1;
        private List<M4> _m4;
        private List<M40> _m40;
        private List<M500> _m500;
        private List<M9> _m9;
        private List<MBITR> _mbitr;
        private List<PEQ15> _peq15;
        private List<PEQ2> _peq2;
        private List<PVS14> _pvs14;
        private List<PVS7> _pvs7;
        private List<OtherItems> _otherItems;
        private List<SensitiveItemBaseClass> _allItems;
        private Dictionary<double, string> _siDictionary;
        public SensitiveItemList()
        {
            _acogs      = new List<ACOG>();
            _asip       = new List<Asip>();
            _cco        = new List<CCO>();
            _m145       = new List<M145>();
            _m240b      = new List<M240B>();
            _m249       = new List<M249>();
            _m320a1     = new List<M320A1>();
            _m4         = new List<M4>();
            _m40        = new List<M40>();
            _m500       = new List<M500>();
            _m9         = new List<M9>();
            _mbitr      = new List<MBITR>();
            _peq15      = new List<PEQ15>();
            _peq2       = new List<PEQ2>();
            _pvs14      = new List<PVS14>();
            _pvs7       = new List<PVS7>();
            _otherItems = new List<OtherItems>();
            _siDictionary = new Dictionary<double, string>();
            _allItems = new List<SensitiveItemBaseClass>();
        }
        public Dictionary<double, string> SIDictionary
        {
            get
            {
                return _siDictionary;
            }
            set
            {
                SetProperty(ref _siDictionary, value);
            }
        }
        public List<ACOG> ACOGs
        {
            get
            {
                return _acogs;
            }
            set
            {
                SetProperty(ref _acogs, value);
            }
        }
        public List<Asip> Asip
        {
            get
            {
                return _asip;
            }
            set
            {
                SetProperty(ref _asip, value);
            }
        }
        public List<CCO> CCO
        {
            get
            {
                return _cco;
            }
            set
            {
                SetProperty(ref _cco, value);
            }
        }
        public List<M145> M145
        {
            get
            {
                return _m145;
            }
            set
            {
                SetProperty(ref _m145, value);
            }
        }
        public List<M240B> M240b
        {
            get
            {
                return _m240b;
            }
            set
            {
                SetProperty(ref _m240b, value);
            }
        }
        public List<M249> M249
        {
            get
            {
                return _m249;
            }
            set
            {
                SetProperty(ref _m249, value);
            }
        }
        public List<M320A1> M320A1
        {
            get
            {
                return _m320a1;
            }
            set
            {
                SetProperty(ref _m320a1, value);
            }
        }
        public List<M4> M4
        {
            get
            {
                return _m4;
            }
            set
            {
                SetProperty(ref _m4, value);
            }
        }
        public List<M40> M40
        {
            get
            {
                return _m40;
            }
            set
            {
                SetProperty(ref _m40, value);
            }
        }
        public List<M500> M500
        {
            get
            {
                return _m500;
            }
            set
            {
                SetProperty(ref _m500, value);
            }
        }
        public List<M9> M9
        {
            get
            {
                return _m9;
            }
            set
            {
                SetProperty(ref _m9, value);
            }
        }
        public List<MBITR> MBITR
        {
            get
            {
                return _mbitr;
            }
            set
            {
                SetProperty(ref _mbitr, value);
            }
        }
        public List<PEQ15> PEQ15
        {
            get
            {
                return _peq15;
            }
            set
            {
                SetProperty(ref _peq15, value);
            }
        }
        public List<PEQ2> PEQ2
        {
            get
            {
                return _peq2;
            }
            set
            {
                SetProperty(ref _peq2, value);
            }
        }
        public List<PVS14> PVS14
        {
            get
            {
                return _pvs14;
            }
            set
            {
                SetProperty(ref _pvs14, value);
            }
        }
        public List<PVS7> PVS7
        {
            get
            {
                return _pvs7;
            }
            set
            {
                SetProperty(ref _pvs7, value);
            }
        }
        public List<OtherItems> OtherItems
        {
            get
            {
                return _otherItems;
            }
            set
            {
                SetProperty(ref _otherItems, value);
             
            }
        }
        public List<SensitiveItemBaseClass> AllItems
        {
            get
            {
                return _allItems;
            }
            set
            {
                SetProperty(ref _allItems, value);
            }
        }

    }
}
