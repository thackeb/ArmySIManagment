using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
namespace ArmySIManagment.BuisnessLogic.Models
{
    public class WeaponAssignments : BaseModel
    {
        private Roles _role;

        private List<SensitiveItemBaseClass> _assignedSI;
     

        public List<SensitiveItemBaseClass> AssignedSI
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


        public Roles Role
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
        public WeaponAssignments()
        {
            AssignedSI = new List<SensitiveItemBaseClass>();
            Role = new Roles();
        }
        public WeaponAssignments( SensitiveItemBaseClass siList, Roles newRole)
        {
            AssignedSI = new List<SensitiveItemBaseClass>();
            AssignedSI.Add(siList);
            Role = newRole;
        }

       
    }
}
