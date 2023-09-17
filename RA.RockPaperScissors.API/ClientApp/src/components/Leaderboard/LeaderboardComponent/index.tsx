import React, { FunctionComponent } from "react";
import { LeaderboardDto, PlayerDto } from "../../../models";

interface ILeaderboardComponentProps {
    leaderboard: LeaderboardDto
}

const LeaderboardComponent: FunctionComponent<ILeaderboardComponentProps> = ({leaderboard}) => {
    return (
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Score</th>
          </tr>
        </thead>
        <tbody>
          {leaderboard?.players?.map((player: PlayerDto, index) => {
            return (
              <tr key={player.id}>
                <td>{`Player ${index + 1}`}</td>
                <td>{player.score}</td>
              </tr>
            );
          })}
        </tbody>
      </table>
    );
};

export default LeaderboardComponent;
