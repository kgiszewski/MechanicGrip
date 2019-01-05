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
deck.Shuffle(100); //shuffle the cards for 100 iterations
deck.Cut(); //cuts the decks once
deck.Cut(100); //cuts the decks 100 times
deck.Cards; //returns a list of cards as List<ICard>
deck.Deal(); //deal out the cards with some options as IEnumerable<IEnumberable<ICard>>
deck.Draw(); //grab the top card
```

## Extensible
You can implements your own:
- Decks
- Ranks
- Suits
- Deal Patterns

Overloads so you can mix and match deal patterns.

It's totally up to you how to create each of those.

## Nuget
Get it on Nuget: https://www.nuget.org/packages/MechanicGrip
