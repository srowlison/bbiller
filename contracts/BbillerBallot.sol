pragma solidity ^0.4.0;

import './BbillerToken.sol';
import './ownership/Ownable.sol';

contract BbillerBallot is Ownable {
    BbillerToken public token;
    mapping(uint => Issue) public issues;

    uint issueDoesNotExistFlag = 0;
    uint issueVotingFlag = 1;
    uint issueAcceptedFlag = 2;
    uint issueRejectedFlag = 3;

    struct Issue {
        uint votingStartDate;
        uint votingEndDate;
        mapping(address => bool) isVoted;
        uint forCounter;
        uint againstCounter;
        uint flag;
    }

    event CreateIssue(uint _issueId, uint _votingStartDate, uint _votingEndDate, address indexed creator);
    event Vote(uint issueId, bool forVote, address indexed voter);
    event IssueAccepted(uint issueId);
    event IssueRejected(uint issueId);

    function BbillerBallot(BbillerToken _token) public {
        token = _token;
    }

    function createIssue(uint issueId, uint _votingStartDate, uint _votingEndDate) public onlyOwner {
        require(issues[issueId].flag == issueDoesNotExistFlag);

        Issue memory issue = Issue(
            {votingEndDate : _votingEndDate,
            votingStartDate : _votingStartDate,
            forCounter : 0,
            againstCounter : 0,
            flag : issueVotingFlag});
        issues[issueId] = issue;

        CreateIssue(issueId, _votingStartDate, _votingEndDate, msg.sender);
    }

    function vote(uint issueId, bool forVote) public {
        require(token.isTokenUser(msg.sender));

        Issue storage issue = issues[issueId];
        require(!issue.isVoted[msg.sender]);
        require(issue.flag == issueVotingFlag);
        require(issue.votingEndDate > now);
        require(issue.votingStartDate < now);

        issue.isVoted[msg.sender] = true;
        if (forVote) {
            issue.forCounter++;
        }
        else {
            issue.againstCounter++;
        }
        Vote(issueId, forVote, msg.sender);

        uint tokenUserCounterHalf = getTokenUserCounterHalf();
        if (issue.forCounter >= tokenUserCounterHalf) {
            issue.flag = issueAcceptedFlag;
            IssueAccepted(issueId);
        }
        if (issue.againstCounter >= tokenUserCounterHalf) {
            issue.flag = issueRejectedFlag;
            IssueRejected(issueId);
        }
    }

    function getVoteResult(uint issueId) public view returns (string) {
        Issue storage issue = issues[issueId];
        if (issue.flag == issueVotingFlag) {
            return 'Voting';
        }
        if (issue.flag == issueAcceptedFlag) {
            return 'Accepted';
        }
        if (issue.flag == issueRejectedFlag) {
            return 'Rejected';
        }
        if (issue.flag == issueDoesNotExistFlag) {
            return 'DoesNotExist';
        }
    }

    function getTokenUserCounterHalf() internal returns (uint) {
        // for division must be of uint type
        uint half = 2;
        uint tokenUserCounter = token.getTokenUserCounter();
        uint tokenUserCounterHalf = tokenUserCounter / half;
        if (tokenUserCounterHalf * half != tokenUserCounter) {
            // odd case
            tokenUserCounterHalf++;
        }
        return tokenUserCounterHalf;
    }
}
