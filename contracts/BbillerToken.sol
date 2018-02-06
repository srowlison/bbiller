pragma solidity ^0.4.0;

import './base/MintableToken.sol';

contract BbillerToken is MintableToken {
    string public symbol = 'BBILLER';
    uint public decimals = 18;
    uint public tokenUserCounter;  // number of users that owns this token

    mapping(address => bool) public isTokenUser;

    event CountTokenUser(address _tokenUser, uint _tokenUserCounter, bool increment);

    function getTokenUserCounter() public view returns (uint) {
        return tokenUserCounter;
    }

    function countTokenUser(address tokenUser) internal {
        if (!isTokenUser[tokenUser]) {
            isTokenUser[tokenUser] = true;
            tokenUserCounter++;
        }
        CountTokenUser(tokenUser, tokenUserCounter, true);
    }

    function transfer(address to, uint256 value) public returns (bool) {
        bool res = super.transfer(to, value);
        countTokenUser(to);
        return res;
    }

    function transferFrom(address from, address to, uint256 value) public returns (bool) {
        bool res = super.transferFrom(from, to, value);
        countTokenUser(to);
        if (balanceOf(from) <= 0) {
            isTokenUser[from] = false;
            tokenUserCounter--;
            CountTokenUser(from, tokenUserCounter, false);
        }
        return res;
    }

    function mint(address _to, uint256 _amount) onlyOwner canMint public returns (bool) {
        bool res = super.mint(_to, _amount);
        countTokenUser(_to);
        return res;
    }
}

