﻿namespace BasicWebServer.Server.Common
{
    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
                name ??= "null";

                throw new ArgumentException($"{name} cannot be null.");
            }
        }
    }
}