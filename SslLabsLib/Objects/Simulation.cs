namespace SslLabsLib.Objects
{
    public class Simulation
    {
        /// <summary>
        /// The client used
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Zero if handshake was successful, 1 if it was not.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Always 1 with the current implementation.
        /// </summary>
        public int Attempts { get; set; }

        /// <summary>
        /// Negotiated protocol ID.
        /// </summary>
        public int ProtocolId { get; set; }

        /// <summary>
        /// Negotiated suite ID.
        /// </summary>
        public int SuiteId { get; set; }
    }
}