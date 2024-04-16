import { Outlet } from "react-router-dom";
import Header from "./main/Header";

function Home() {
  return (
    <div>
      <Header />
      <main>
        <div className="mx-auto max-w-7xl py-6 sm:px-6 lg:px-8">
            <Outlet />
        </div>
      </main>
    </div>
  );
}

export default Home;
