using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapplication.core.Entity.Concrete;

namespace webapplication.core.Utilities.Security.JWT
{

    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }


}
