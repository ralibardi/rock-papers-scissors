import React, { useEffect, useState } from "react";

import { LeaderboardDto } from "./models";
import { getLeaderboard, getPlayersBeforeGameStarts } from "./services";
import { GameComponent } from "./components/Game";
import { LeaderboardComponent } from "./components/Leaderboard";

import "./App.scss";

function App() {
  const [leaderboard, setLeaderboard] = useState<LeaderboardDto | null>(null);
  const [gameCounter, setGameCounter] = useState(0);

  useEffect(() => {
    if (gameCounter >= 0) {
      getLeaderboard().then(setLeaderboard).catch(console.error);
    } else {
      getPlayersBeforeGameStarts().then(setLeaderboard).catch(console.error);
    }
  }, []);

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
}

export default App;
