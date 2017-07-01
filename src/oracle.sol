pragma solidity ^0.4.9;

contract Oracle{
    uint256 public _DayAvgPrice;
    uint256 public _DayHighestPrice;
    uint256 public _DayLowestPrice;
    uint256 public _LastPrice;

    address _owner;
    
	function Oracle()
    {
        _owner = msg.sender;
    }

	function update(uint256 dayAvgPrice, uint256 dayHighestPrice, uint256 dayLowestPrice, uint256 lastPrice)
    {
        if (msg.sender == _owner)
        {
            _DayAvgPrice = dayAvgPrice;
            _DayHighestPrice = dayHighestPrice;
            _DayLowestPrice = dayLowestPrice;
            _LastPrice = lastPrice;
        }
    }

	function DayAvgPrice() constant returns(uint256 dayAvgPrice)
    {
        return _DayAvgPrice;
    }

    function DayHighestPrice() constant returns(uint256 dayHighestPrice)
    {
        return _DayHighestPrice;
    }

    function DayLowestPrice() constant returns(uint256 dayLowePrice)
    {
        return _DayLowestPrice;
    }

    function LastPrice() constant returns(uint256 lastPrice)
    {
        return _LastPrice;
    }
}