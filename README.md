# MechanicGrip
A model of a simple deck of cards in C#

I'm writing this to support my hobby project EuchreTime (also on GitHub).

So far these decks are modeled:
- Standard Deck
- Euchre Deck

## Deck Methods

```
var deck = new StandardDeck(); //or whatever deck you pick

deck.Shuffle(); //shuffle the cards for one iteration
deck.Cut(); //cuts the decks
deck.Cards; //returns a list of cards as Stack<ICard>

```
