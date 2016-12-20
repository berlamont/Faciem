using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Faciem.Infrastructure
{
    public class OxfordException : Exception
    {
        public OxfordException() { }

	    public OxfordException(string message) : base(message)
	    {
		    
	    }

	    public OxfordException(string message, Exception innerException) : base(message, innerException)
	    {
		    
	    }

	    public OxfordException(string message, Exception innerException, [CallerMemberName] string caller = "") : base(message, innerException)
	    {
		    
	    }
    }
}
