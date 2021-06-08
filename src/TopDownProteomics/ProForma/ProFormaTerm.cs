﻿using System.Collections.Generic;

namespace TopDownProteomics.ProForma
{
    /// <summary>
    /// Represents a ProForma string in memory.
    /// </summary>
    public class ProFormaTerm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProFormaTerm" /> class.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <param name="tags">The tags.</param>
        /// <param name="nTerminalDescriptors">The n terminal descriptors.</param>
        /// <param name="cTerminalDescriptors">The c terminal descriptors.</param>
        /// <param name="labileDescriptors">The labile modification descriptors.</param>
        /// <param name="unlocalizedTags">Unlocalized modification tags.</param>
        /// <param name="tagGroups">The tag groups.</param>
        /// <param name="globalModifications">The global modifications.</param>
        /// <param name="ambiguousAASequences">Ambiguous amino acids tags (Example: XXX(?NKK)XXX). Contain only start and end indexes for the ambiguous residues.</param>
        public ProFormaTerm(string sequence, IList<ProFormaTag>? tags = null, IList<ProFormaDescriptor>? nTerminalDescriptors = null,
            IList<ProFormaDescriptor>? cTerminalDescriptors = null, IList<ProFormaDescriptor>? labileDescriptors = null,
            IList<ProFormaUnlocalizedTag>? unlocalizedTags = null, ICollection<ProFormaTagGroup>? tagGroups = null,
            IList<ProFormaGlobalModification>? globalModifications = null, IList<ProFormaTag>? ambiguousAASequences = null)
        {
            this.Sequence = sequence;
            this.NTerminalDescriptors = nTerminalDescriptors;
            this.CTerminalDescriptors = cTerminalDescriptors;
            this.LabileDescriptors = labileDescriptors;
            this.Tags = tags;
            this.UnlocalizedTags = unlocalizedTags;
            this.TagGroups = tagGroups;
            this.GlobalModifications = globalModifications;
            this.AmbiguousAASequences = ambiguousAASequences;
        }

        /// <summary>The amino acid sequence.</summary>
        public string Sequence { get; }

        /// <summary>Modifications that apply globally based on a target or targets.</summary>
        public IList<ProFormaGlobalModification>? GlobalModifications { get; }

        /// <summary>N-Terminal descriptors.</summary>
        public IList<ProFormaDescriptor>? NTerminalDescriptors { get; }

        /// <summary>C-Terminal descriptors.</summary>
        public IList<ProFormaDescriptor>? CTerminalDescriptors { get; }

        /// <summary>Labile modifications (not visible in the fragmentation MS2 spectrum) descriptors.</summary>
        public IList<ProFormaDescriptor>? LabileDescriptors { get; }

        /// <summary>All tags on this term.</summary>
        public IList<ProFormaTag>? Tags { get; }

        /// <summary>Descriptors for modifications that are completely unlocalized.</summary>
        public IList<ProFormaUnlocalizedTag>? UnlocalizedTags { get; }

        /// <summary>All tag groups for this term.</summary>
        public ICollection<ProFormaTagGroup>? TagGroups { get; }

        /// <summary>"Tags" for ambiguous amino acid sequences (Example: XXX(?NKK)XXX). Contain only start and end indexes for the ambiguous residues.</summary>
        public IList<ProFormaTag>? AmbiguousAASequences { get; }
    }
}