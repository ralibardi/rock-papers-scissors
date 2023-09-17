import { FunctionComponent, useEffect, useState } from "react";
import { GameComponent } from "../components/Game";
import { LeaderboardComponent } from "../components/Leaderboard";
import { LeaderboardDto } from "../models";
import { getLeaderboard } from "../services";

import "./ApplicationPage.scss";

interface IApplicationProps {
  leaderboard: LeaderboardDto;
  onSetLeaderboard: (leaderboard: LeaderboardDto) => void;
}

const ApplicationPage: FunctionComponent<IApplicationProps> = ({
  leaderboard,
  onSetLeaderboard,
}) => {
  const [gameCounter, setGameCounter] = useState(0);

  useEffect(() => {
    if (gameCounter >= 0) {
      getLeaderboard().then(onSetLeaderboard).catch(console.error);
    }
  }, [gameCounter]);

  function onResult() {
    setGameCounter(gameCounter + 1);
  }

  return (
    <>
      <h1>{`Game ${gameCounter}`}</h1>
      <div className="app__container">
        {leaderboard?.players && (
          <GameComponent leaderboard={leaderboard} onResult={onResult} />
        )}
        {leaderboard && <LeaderboardComponent leaderboard={leaderboard} />}
      </div>
    </>
  );
};

export default ApplicationPage;