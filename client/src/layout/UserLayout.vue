<template>
  <div id="container">
    <div class="user-logo-lang">
      <a href="">
        <img src="../assets/logo.png" alt="" />
      </a>
    </div>
    <a-layout>
      <a-layout-header>
        <a href="">
          <img class="logo" src="../assets/logo.png" alt="" />
          <span class="title">登录页面</span>
        </a>
        <div class="desc">
          的法大师傅士大夫士大夫士大夫士大夫但是撒旦飞洒飞洒地方撒旦范德萨发生
        </div>
      </a-layout-header>
      <a-layout-content>
        <login-form></login-form>
      </a-layout-content>
      <a-layout-footer>Footer</a-layout-footer>
    </a-layout>
  </div>
</template>

<script>
import LoginForm from "../components/LoginForm";

export default {
  components: { "login-form": LoginForm },
  name: "UserLayout",
};
</script>

<style lang="less" scoped>
#container {
  .user-logo-lang {
    text-align: right;
    height: 40px;
    position: relative;
    line-height: 44px;
    img {
      width: 20px;
      height: 20px;
    }
  }
  .ant-layout-header {
    text-align: center;
    padding: 30px 0 10px;
    height: 130px;
    a {
      text-decoration: none;
    }
    .logo {
      width: 50px;
      height: 50px;
      margin-right: 16px;
      vertical-align: top;
    }
    .title {
      font-size: 32px;
      font-weight: 400;
      top: 2px;
    }
    .desc {
      font-size: 14px;
      color: white;
      line-height: 20px;
    }
  }
}
</style>