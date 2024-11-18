#ifndef WRAPPEDTEXT_HPP_
#define WRAPPEDTEXT_HPP_
#include <SFML/Graphics.hpp>
#include <string>
class WrappedText : public sf::Text {
private:
    std::string base;
    float sizeLimit;
public:
    WrappedText(const std::string& base, const sf::Font& font, const float& sizeLimit, const unsigned int& charSize)
        : sf::Text(base, font, charSize), base(base), sizeLimit(sizeLimit) { recalculate(); }
    void recalculate() {
        setString("");
        std::string ansi("");
        std::string newStr("");
        char character = 0;
        size_t lastSpace = 0;
        for (size_t cPos = 0; cPos <= base.length(); cPos++) {
            character = base[cPos];
            newStr += (getString() + character);
            if ((findCharacterPos(cPos) - getPosition()).x > sizeLimit) {
                ansi = getString().toAnsiString();
                lastSpace = ansi.find_last_of(' ');
                newStr += (lastSpace >= 0 ? ansi.substr(0, lastSpace) + "\n" + ansi.substr(lastSpace + 1) : ansi + '\n');
            }
        }
        // idk this is pretty cursed, but it removes some random character
        setString(newStr.substr(0, newStr.size() - 1));
    }
    void updateBase(const std::string& base) {
        this->base = base;
    }
    std::string getBase() const {
        return base;
    }
};
#endif
