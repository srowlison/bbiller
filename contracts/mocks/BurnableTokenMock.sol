pragma solidity ^0.4.18;

import '../base/BurnableToken.sol';

contract BurnableTokenMock is BurnableToken {

    function BurnableTokenMock(address initialAccount, uint initialBalance) public {
        balances[initialAccount] = initialBalance;
        totalSupply = initialBalance;
    }

}
