import React, { FunctionComponent, useEffect, useRef, useState } from "react";
import { LeaderboardDto, PlayerDto } from "../../../models";
import { RockPaperScissors } from "../../../enums";
import { getPlayerMatch, patchPlayer } from "../../../services";
import { getRandomValueFromEnum } from "../../../utilities";
import PlayerChoice from "../PlayerChoice";
import PlayerTitle from "../PlayerTitle.tsx";

import "./GameComponent.scss";

interface IGameComponentProps {
  leaderboard: LeaderboardDto;
  onResult: () => void;
}

const GameComponent: FunctionComponent<IGameComponentProps> = ({
  leaderboard,
  onResult,
}) => {
  const [isWinner, setIsWinner] = useState<boolean | null>(null);

  function handleChange(player: PlayerDto, checked: boolean) {
    const data = { ...player, isHuman: checked };
    patchPlayer(data);
    onResult();
  }

  function onClick(move: RockPaperScissors) {
    const humanMove: RockPaperScissors =
      move === RockPaperScissors.None
        ? getRandomValueFromEnum(RockPaperScissors)
        : move;
    const computerMove: RockPaperScissors =
      getRandomValueFromEnum(RockPaperScissors);
    
    const humanPlayerIndex = leaderboard.players.findIndex(p => p.isHuman);
    const humanPlayer = leaderboard.players[humanPlayerIndex !== -1 ? humanPlayerIndex : 0];
    const computerPlayer =
      leaderboard.players[1 - humanPlayerIndex];

    const player1: PlayerDto = {
      ...humanPlayer,
      lastMove: humanMove,
    };
    const player2: PlayerDto = {
      ...computerPlayer,
      lastMove: computerMove,
    };

    getPlayerMatch(player1, player2).then((p) => {
      setIsWinner(p && p.id === player1.id);
    });
    onResult();
  }

  return (
    <React.Fragment>
      <div className="game__container">
        <div className="game__header">
          {leaderboard.players.map((player, index) => (
            <PlayerTitle
              key={player.id}
              player={player}
              handleChange={handleChange}
              isChangeEnabled={index !== leaderboard.players.length - 1}
            />
          ))}
        </div>
        <div className="game__board">
          {leaderboard.players.map((player, index) => (
            <PlayerChoice
              key={player.id}
              isPlayerHuman={player.isHuman}
              isChoiceEnabled={index !== leaderboard.players.length - 1}
              onClick={onClick}
            />
          ))}
          {leaderboard.players.filter((p) => p.isHuman).length === 0 && (
            <button
              type="button"
              className="player-choice__button"
              onClick={onClick.bind(null, RockPaperScissors.None)}
            >
              Automatic
            </button>
          )}
        </div>
      </div>
      {isWinner !== null && (
        <div className="game__footer">
          <div className="game__winner">
            <h3>{isWinner ? "Player 1 won!" : "Player 2 won!"}</h3>
          </div>
        </div>
      )}
    </React.Fragment>
  );
};

export default GameComponent;
