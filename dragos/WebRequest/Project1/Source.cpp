// ConsoleApplication1.cpp : Defines the entry point for the console application.
//
#include <list>
#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

int main()
{
	list<string> words;

	int n;
	cin >> n;

	for (int i = 0; i < n; i++) {
		string word;
		cin >> word;
		words.push_back(word);
	}

	int filter;
	cin >> filter;

	for (auto i = words.rbegin(); i != words.rend(); i++) {
		if (i->length() == filter) {
			string saved = *i;
			words.remove(saved);
			words.push_front(saved);
		}
	}

	cout << "\n\n\n\n";
	for (string i : words) {
		cout << i << "\n";
	}

	getchar();
	getchar();
	return 0;
}

