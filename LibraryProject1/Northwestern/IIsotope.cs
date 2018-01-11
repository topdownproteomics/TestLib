﻿namespace TestLibNamespace.Northwestern
{
    /// <summary>
    /// A naturally occurring isotope of an element
    /// </summary>
    public interface IIsotope
    {
        /// <summary>
        /// The atomic mass in daltons (Da).
        /// </summary>
        double AtomicMass { get; }

        /// <summary>
        /// The occurance of this isotope relative to others from a given element.
        /// </summary>
        /// <value>
        /// The abundance as a percentage from 0-1.
        /// </value>
        double Abundance { get; }
    }
}