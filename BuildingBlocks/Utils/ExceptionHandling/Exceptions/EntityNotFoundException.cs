using System;

namespace BuildingBlocks.Utils.Exceptions {
    public class EntityNotFoundException : Exception {

        public string message { get; set; }

        public override string Message {
            get { return this.message; }
        }

        public EntityNotFoundException(string message) {
            this.message = message;
        }

        

    }
}
