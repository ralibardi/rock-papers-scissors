import React, { useEffect, useState } from "react";
import { LeaderboardDto } from "./models";
import ApplicationPage from "./pages/ApplicationPage";
import { getPlayersBeforeGameStarts } from "./services";

function App() {
  const [leaderboard, setLeaderboard] = useState<LeaderboardDto | null>(null);

  useEffect(() => {
    getPlayersBeforeGameStarts().then(setLeaderboard).catch(console.error);
  }, []);

  function onSetLeaderboard (leaderboard: LeaderboardDto) {
    setLeaderboard(leaderboard);
  };

  return (
    <>
      {leaderboard && (
        <ApplicationPage
          leaderboard={leaderboard}
          onSetLeaderboard={onSetLeaderboard}
        />
      )}
    </>
  );
}

export default App;
