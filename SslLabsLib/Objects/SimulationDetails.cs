using System.Collections.Generic;
using Newtonsoft.Json;

namespace SslLabsLib.Objects
{
    public class SimulationDetails
    {
        /// <summary>
        /// Simulations
        /// </summary>
        [JsonProperty("Results")]
        public List<Simulation> Simulations { get; set; }
    }
}