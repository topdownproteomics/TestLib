﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TopDownProteomics.Chemistry
{
    /// <summary>
    /// Element provider that takes injected elements, indexes them, and returns them quickly.
    /// </summary>
    /// <seealso cref="IElementProvider" />
    public class InMemoryElementProvider : IElementProvider
    {
        private IElement[] _elements;
        private IElement[] _by_atomic_number;
        private Dictionary<string, IElement> _by_symbol;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryElementProvider"/> class.
        /// </summary>
        /// <param name="elements">The elements.</param>
        public InMemoryElementProvider(IElement[] elements)
        {
            _elements = elements;

            if (elements != null)
                this.IndexElements(elements);
        }

        private void IndexElements(IElement[] elements)
        {
            int capacity = elements.Max(x => x.AtomicNumber);
            _by_atomic_number = new IElement[capacity];
            _by_symbol = new Dictionary<string, IElement>(capacity);

            for (int i = 0; i < elements.Length; i++)
            {
                _by_atomic_number[elements[i].AtomicNumber] = elements[i];
                _by_symbol[elements[i].Symbol] = elements[i];
            }
        }

        /// <summary>
        /// Gets the element by atomic number.
        /// </summary>
        /// <param name="atomicNumber">The atomic number.</param>
        /// <param name="fixedIsotopeNumber">Get a fixed isotope element with the given number of subatomic particles in the nucleus.</param>
        /// <returns></returns>
        public IElement GetElement(int atomicNumber, int? fixedIsotopeNumber = null)
        {
            if (!fixedIsotopeNumber.HasValue)
                return _by_atomic_number[atomicNumber];

            return this.GetFixedIsotopeElement(_by_atomic_number[atomicNumber], fixedIsotopeNumber.Value);
        }

        /// <summary>
        /// Gets the element by symbol.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="fixedIsotopeNumber">Get a fixed isotope element with the given number of subatomic particles in the nucleus.</param>
        /// <returns></returns>
        public IElement GetElement(string symbol, int? fixedIsotopeNumber = null)
        {
            if (!fixedIsotopeNumber.HasValue)
                return _by_symbol[symbol];

            return this.GetFixedIsotopeElement(_by_symbol[symbol], fixedIsotopeNumber.Value);
        }

        private IElement GetFixedIsotopeElement(IElement element, int fixedIsotopeNumber)
        {
            IIsotope oldIsotope = element.Isotopes
                .Single(x => x.NeutronCount == fixedIsotopeNumber - element.AtomicNumber);
            IIsotope newIsotope = new Isotope(element.AtomicNumber, oldIsotope.NeutronCount, 1.0);

            return new Element(element.AtomicNumber, element.Symbol,
                new ReadOnlyCollection<IIsotope>(new[] { newIsotope }));
        }
    }
}