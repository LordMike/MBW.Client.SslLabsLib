using System.Collections.Generic;

namespace SslLabsLib.Objects
{
    public class StatusCodes
    {
        /// <summary>
        /// A map containing all status details codes and the corresponding English translations. 
        /// Please note that, once in use, the codes will not change, whereas the translations may change at any time.
        /// </summary>
        public Dictionary<string,string> StatusDetails { get; set; }
    }
}