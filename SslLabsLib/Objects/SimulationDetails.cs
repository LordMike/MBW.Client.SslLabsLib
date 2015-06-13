using System.Collections.Generic;
using RestSharp.Deserializers;

namespace SslLabsLib.Objects
{
    public class SimulationDetails
    {
        /// <summary>
        /// Simulations
        /// </summary>
        [DeserializeAs(Name = "Results")]
        public List<Simulation> Simulations { get; set; }
    }
}