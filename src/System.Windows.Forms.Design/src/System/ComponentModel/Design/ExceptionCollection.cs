﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections;
using System.Runtime.Serialization;

namespace System.ComponentModel.Design
{
    // TODO: determine if Serializable attribute is necessary; also is this class necessary?
    public sealed class ExceptionCollection : Exception
    {
        private readonly ArrayList _exceptions;

        public ExceptionCollection(ArrayList exceptions)
        {
            _exceptions = exceptions;
        }

        private ExceptionCollection(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _exceptions = (ArrayList)info.GetValue("exceptions", typeof(ArrayList));
        }

        public ArrayList Exceptions => (ArrayList)_exceptions?.Clone();

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("exceptions", _exceptions);
            base.GetObjectData(info, context);
        }
    }
}
