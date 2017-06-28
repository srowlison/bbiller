pragma solidity ^0.4.9;

contract oracleTest {
    bytes32 public rate;

    function otest() {
        //use brave new coin oracle 0x25dc90faa727aa29e437e660e8f868c9784d3828, checked sum 0x25Dc90FAa727aa29e437E660e8F868C9784D3828
        Oracle o = Oracle(0x25Dc90FAa727aa29e437E660e8F868C9784D3828);
        rate = o.current();
    }
}

contract Oracle{
	function Oracle();
	function update(bytes32 newCurrent);
	function current()constant returns(bytes32 current);
}