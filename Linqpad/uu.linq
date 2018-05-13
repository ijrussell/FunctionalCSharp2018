<Query Kind="Statements" />

Func<int, int> triple = x => x * 3;
var range = Enumerable.Range(1, 3);
var triples = range.Select(triple);
triples = Enumerable.Range(1, 3).Select(triple);
range.Dump();
triples.Dump();

(double lat, double lng) GetLatLng(string address) 
{ 
	return (100.0, 234.0);
}

var coods = GetLatLng("");

coods.lat.Dump();
coods.lng.Dump();

var (lat2, lng2) = GetLatLng("");

lat2.Dump();
lng2.Dump();

