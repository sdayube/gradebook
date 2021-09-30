// <copyright file="NamedObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GradeBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Controls the Name property of a given instance.</summary>
    public class NamedObject
    {
        public NamedObject(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
