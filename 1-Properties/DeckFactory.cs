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
        public string[] Seeds 
        { get => _seeds; 
        set{
            _seeds = value.ToArray();
        } }

        private string[] _name;
        public string[] Names {get; set; }

        // TODO improve
       // public IList<string> GetSeeds() => _seeds.ToList();

        // TODO improve
       // public void SetSeeds(IList<string> seeds)
       // {
       //     _seeds = seeds.ToArray();
       // }

        // TODO improve
        //public IList<string> GetNames() => _names.ToList();

        // TODO improve
        //public void SetNames(IList<string> names)
        //{
        //    _names = names.ToArray();
        //}

        // TODO improve
        public int GetDeckSize() => Names.Length * Seeds.Length;

        /// TODO improve
        public ISet<Card> GetDeck()
        {
            if (Names == null || Seeds == null)
            {
                throw new InvalidOperationException();
            }

            return new HashSet<Card>(Enumerable
                .Range(0, Names.Length)
                .SelectMany(i => Enumerable
                    .Repeat(i, Seeds.Length)
                    .Zip(
                        Enumerable.Range(0, Seeds.Length),
                        (n, s) => Tuple.Create(Names[n], Seeds[s], n)))
                .Select(tuple => new Card(tuple))
                .ToList());
        }
    }
}
