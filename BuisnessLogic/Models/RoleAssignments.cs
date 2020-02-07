using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmySIManagment.BuisnessLogic.Models
{
    public class RoleAssignments : BaseModel
    {
        private Roles _role;
        private Soldier _assignedSoldier;


        public Soldier AssignedSoldier
        {
            get
            {
                return _assignedSoldier;
            }
            set
            {
                SetProperty(ref _assignedSoldier, value);
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
        public RoleAssignments()
        {
            Role = new Roles();
            AssignedSoldier = new Soldier();
        }
        public RoleAssignments( Soldier newSoldier, Roles newRole)
        {
            Role = newRole;
            AssignedSoldier = newSoldier;
        }

    }
}
