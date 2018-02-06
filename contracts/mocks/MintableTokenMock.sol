pragma solidity ^0.4.18;

import '../base/MintableToken.sol';

contract MintableTokenMock is MintableToken {

    function MintableTokenMock(address initialAccount, uint initialBalance) public {
        balances[initialAccount] = initialBalance;
        totalSupply = initialBalance;

    }
}
