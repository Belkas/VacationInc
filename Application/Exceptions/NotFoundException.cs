using System;


namespace Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(int id, string item)
            : base($"{item} with id {id} not found.")
        {
        }

    }
}
