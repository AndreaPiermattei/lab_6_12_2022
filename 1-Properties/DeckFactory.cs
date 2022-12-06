namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] _seeds;

        private string[] _names;

        // TODO improve
        public IList<string> GetSeeds() => _seeds.ToList();

        // TODO improve
        public void SetSeeds(IList<string> seeds)
        {
            _seeds = seeds.ToArray();
        }

        // TODO improve
        public IList<string> GetNames() => names.ToList();

        // TODO improve
        public void SetNames(IList<string> names)
        {
            _names = names.ToArray();
        }

        // TODO improve
        public int GetDeckSize() => _names.Length * _seeds.Length;

        /// TODO improve
        public ISet<Card> GetDeck()
        {
            if (this.names == null || this.seeds == null)
            {
                throw new InvalidOperationException();
            }

            return new HashSet<Card>(Enumerable
                .Range(0, this.names.Length)
                .SelectMany(i => Enumerable
                    .Repeat(i, this.seeds.Length)
                    .Zip(
                        Enumerable.Range(0, this.seeds.Length),
                        (n, s) => Tuple.Create(this.names[n], this.seeds[s], n)))
                .Select(tuple => new Card(tuple))
                .ToList());
        }
    }
}
